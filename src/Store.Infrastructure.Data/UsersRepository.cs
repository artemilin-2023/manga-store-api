using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstracts;
using Store.Domain;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data;

public class UsersRepository(DataContext database, IMapper mapper) : IUsersRepository
{
    private readonly DataContext database = database;
    private readonly IMapper mapper = mapper;

    public async Task AddAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);   
        
        var userEntity = mapper.Map<UserEntity>(user);
        await database.Users.AddAsync(userEntity);

        await database.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var userEntity = await database.Users.FirstAsync(u => u.Id == id);
        return mapper.Map<User>(userEntity);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var userEntity = await database.Users.FirstAsync(u => u.Email == email);
        return mapper.Map<User>(userEntity);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return database.Users.Select(u => mapper.Map<User>(u));
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var user = await database.Users.FirstAsync(u => u.Id == id);
        database.Users.Remove(user);

        await database.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(Guid id, string? name, string? email, string? passwordHash)
    {
        var user = await database.Users.FirstAsync(u => u.Id == id);
        var userEntity = new UserEntity()
        {
            Id = id,
            Name = name ?? user.Name,
            Email = email ?? user.Email,
            PasswordHash = passwordHash ?? user.PasswordHash
        };
        database.Users.Update(userEntity);
        
        await database.SaveChangesAsync();
    }
}