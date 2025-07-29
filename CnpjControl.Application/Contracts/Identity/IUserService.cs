using CnpjControl.Domain.Models.Identity;

namespace CnpjControl.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string userId);
}