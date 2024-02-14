using AutoMapper;
using Moq;
using Store.Domain;
using Store.Infrastructure.Data.Entities;
using Store.Infrastructure.Data.Mappers;
using Store.Infrastructure.Data.Tests.Helpers;

namespace Store.Infrastructure.Data.Tests;

public class UsersRepositoryTests
{
    private UsersRepository usersRepository;
    private DataContext database;
    private IMapper mapper;
    private readonly List<UserEntity> fakeUsersDbSetData = DataHelper.GetFakeUsersData();
    

    [SetUp]
    public void SetUp()
    {
        var databaseMock = new Mock<DataContext>();
        databaseMock.Setup(db => db.Users)
                    .Returns(MockHelper.SetupUsersDbSetMock(fakeUsersDbSetData));
        database = databaseMock.Object;
        
        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<UserMappingProfile>());
        mapper = new Mapper(mapperConfig);
        
        usersRepository = new UsersRepository(database, mapper);
    }

    [Test]
    public void AddAsync_Null_CatchException()
    {
        Assert.That(async () => await usersRepository.AddAsync(null), Throws.ArgumentNullException);
    }

    [Test]
    public async Task AddAsync_CorrectUserEntity_AddUserToDb()
    {
        var newUser = new User(Guid.NewGuid(), "test-user-1", "test@mail.ru", "qwerty");

        await usersRepository.AddAsync(newUser);
        var expected = mapper.Map<UserEntity>(newUser);
        Assert.That(fakeUsersDbSetData[^1] == expected, Is.True);
    }
}