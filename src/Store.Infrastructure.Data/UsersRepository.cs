using Store.Application.Abstracts;
using Store.Domain;
using Store.Infrastructure.Data.DataContexts;

namespace Store.Infrastructure.Data;

public class UsersRepository : IUsersRepository
{
    private readonly DataContext database;

    public UsersRepository(DataContext dataContext)
    {
        database = dataContext;
    }
    
    public async Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserAsync(Guid id, string username, string email, string passwordHash)
    {
        throw new NotImplementedException();
    }
}