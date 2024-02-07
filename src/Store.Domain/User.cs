namespace Store.Domain;

public class User
{
    public const int MaxNameLength = 50;
    
    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string PasswordHash { get; }
    public Roles Role { get; }

    public User(Guid id, string name, string email, string passwordHash, Roles role = Roles.User)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrEmpty(email, nameof(email));
        ArgumentNullException.ThrowIfNullOrEmpty(passwordHash, nameof(passwordHash));

        if (name.Length > MaxNameLength)
            throw new ArgumentOutOfRangeException(nameof(name),"Слишком длинное имя");

        Id = id;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
}