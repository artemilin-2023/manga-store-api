using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Store.Domain;
using Store.Infrastructure.Data.Entities;
using Store.Infrastructure.Data.Mappers;

namespace Store.Infrastructure.Data.Tests;

public class UsersRepositoryTests
{
    private UsersRepository usersRepository;

    [SetUp]
    public void SetUp()
    {
        var dbContextMock = new Mock<DataContext>();
        dbContextMock
            .Setup<DbSet<UserEntity>>(x => x.Users)
            .ReturnsDbSet(TestDataHelper.GetFakeUsersDbSet());

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserMappingProfile>();
        });
        var mapper = new Mapper(mapperConfig);

        usersRepository = new UsersRepository(dbContextMock.Object, mapper);
    }

    [Test]
    public void AddAsync_Null()
    {
        
    }
}