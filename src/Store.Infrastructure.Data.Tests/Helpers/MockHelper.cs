using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moq;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.Tests.Helpers;

public static class MockHelper
{
    public static Mock<DbSet<TItem>> CreateQueryableMockDbSet<TItem>(IEnumerable<TItem> dataList)
        where TItem : class
    {
        var queryableList = dataList.AsQueryable();
        var queryableMock = new Mock<DbSet<TItem>>();
        
        queryableMock.As<IQueryable<TItem>>().Setup(m => m.Provider).Returns(queryableList.Provider);
        queryableMock.As<IQueryable<TItem>>().Setup(m => m.Expression).Returns(queryableList.Expression);
        queryableMock.As<IQueryable<TItem>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
        queryableMock.As<IQueryable<TItem>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

        return queryableMock;
    }

    public static Mock<DataContext> CreateDatabaseMockWithUsersDbSet(DbSet<UserEntity> dbSet)
    {
        var mockDatabase = new Mock<DataContext>();
        mockDatabase.Setup(x => x.Users).Returns(dbSet);

        return mockDatabase;
    }
}