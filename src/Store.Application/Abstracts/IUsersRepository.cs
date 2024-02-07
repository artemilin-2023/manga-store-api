using Store.Domain;

namespace Store.Application.Abstracts;

public interface IUsersRepository
{
    public Task AddAsync(User user);
    public Task<User> GetByIdAsync(Guid id);
    public Task<User> GetByEmailAsync(string email);
    public Task<IEnumerable<User>> GetAllAsync();
    public Task DeleteByIdAsync(Guid id);
    public Task UpdateUserAsync(Guid id, string username, string email, string passwordHash);
}