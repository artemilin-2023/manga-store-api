using Store.Domain;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.Tests;

public static class TestDataHelper
{
    public static List<UserEntity> GetFakeUsersDbSet()
    {
        return
        [
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Name = "First",
                PasswordHash = "aalsdkjfa;lsdj.fkei2-03949",
                Role = Roles.Admin
            },
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "secondUserEmail@yandex.ru",
                Name = "LightChimera",
                PasswordHash = "sha256",
                Role = Roles.PremiumUser
            },
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "lastuser@yandex.ru",
                Name = "Montech",
                PasswordHash = "qwerty",
                Role = Roles.User
            }
        ];
    }
}