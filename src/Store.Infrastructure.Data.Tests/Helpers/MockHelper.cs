using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.Tests.Helpers;

public static class MockHelper
{
    public static DbSet<UserEntity> SetupUsersDbSetMock(List<UserEntity> dataList)
    {
        var mockSet = CreateMockWithBaseSetup(dataList);
        
        mockSet.Setup(db => db.AddAsync(It.IsAny<UserEntity>(), It.IsAny<CancellationToken>()))
                .Callback<UserEntity, CancellationToken>((item, token) => dataList.Add(item));

        // mockSet.Setup(set => set.FirstAsync(It.IsAny<>(), It.IsAny<CancellationToken>())

        return mockSet.Object;
    }

    private static Mock<DbSet<T>> CreateMockWithBaseSetup<T>(IEnumerable<T> dataList) where T : class
    {
        var queryableList = dataList.AsQueryable();
        
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableList.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableList.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

        return mockSet;
    }
}