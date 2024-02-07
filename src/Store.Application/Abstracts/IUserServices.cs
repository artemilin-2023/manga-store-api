namespace Store.Application.Abstracts;

public interface IUserServices
{
    public Task Login(string email, string password);
}