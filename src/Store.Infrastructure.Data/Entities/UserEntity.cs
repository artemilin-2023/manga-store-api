using Store.Domain;

namespace Store.Infrastructure.Data.Entities;

public class UserEntity : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Roles Role { get; set; }
    
    public static bool operator== (UserEntity right, UserEntity left)
    {
        return right.Name == left.Name &&
               right.Email == left.Email &&
               right.PasswordHash == left.PasswordHash &&
               right.Role == left.Role;
    }

    public static bool operator!= (UserEntity right, UserEntity left)
    {
        return right.Name != left.Name ||
               right.Email != left.Email ||
               right.PasswordHash != left.PasswordHash ||
               right.Role != left.Role;
    }
}