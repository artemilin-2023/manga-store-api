using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Store.Domain;
using Store.Infrastructure.Data.Entities;
using Store.Infrastructure.Data.Mappers;
using Store.Infrastructure.Data.Tests.Helpers;

namespace Store.Infrastructure.Data.Tests;

public class UsersRepositoryTests
{
    private IMapper mapper;
    private Mock<DbSet<UserEntity>> mockDbSet;
    private List<UserEntity> fakeUserData = DataHelper.GetFakeUsersData();
    
    [SetUp]
    public void SetUp()
    {
        mockDbSet = MockHelper.CreateQueryableMockDbSet(fakeUserData);
        
        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<UserMappingProfile>());
        mapper = new Mapper(mapperConfig);
    }

    [Test]
    public void AddAsync_Null_CatchException()
    {
        mockDbSet.Setup(set => set.AddAsync(It.IsAny<UserEntity>(), It.IsAny<CancellationToken>()))
                 .Callback<UserEntity, CancellationToken>((item, token) => fakeUserData.Add(item));
        var database = MockHelper.CreateDatabaseMockWithUsersDbSet(mockDbSet.Object).Object;
        
        var usersRepository = new UsersRepository(database, mapper);
        
        Assert.That(async () => await usersRepository.AddAsync(null), Throws.ArgumentNullException);
    }

    [Test]
    public async Task AddAsync_CorrectUserEntity_AddUserToDb()
    {
        var newUser = new User(Guid.NewGuid(), "test-user-1", "test@mail.ru", "qwerty");
        
        // mock set up
        var expression = It.IsAny<Expression<Func<UserEntity, bool>>>();
        mockDbSet.Setup(set => set.FirstAsync(expression, It.IsAny<CancellationToken>()).Result)
                 .Returns(fakeUserData.First(u => u.Id == newUser.Id));
        var database = MockHelper.CreateDatabaseMockWithUsersDbSet(mockDbSet.Object).Object;
        var usersRepository = new UsersRepository(database, mapper);
        
        await usersRepository.AddAsync(newUser);
        var expected = mapper.Map<UserEntity>(newUser);
        Assert.That(fakeUserData[^1] == expected, Is.True);
    }
}