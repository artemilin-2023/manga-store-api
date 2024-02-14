using Store.Domain;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.Tests.Helpers;

public static class DataHelper
{
    public static List<UserEntity> GetFakeUsersData()
    {
        return
        [
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "test@gmail.com",
                Name = "First",
                PasswordHash = "aalsdkjfa;lsdj.fkei2-03949",
                Role = Roles.Admin
            },
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "secondUserEmail@yandex.ru",
                Name = "krevetka",
                PasswordHash = "sha256",
                Role = Roles.PremiumUser
            },
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "lastuser@yandex.ru",
                Name = "user34",
                PasswordHash = "qwerty",
                Role = Roles.User
            }
        ];
    }
}