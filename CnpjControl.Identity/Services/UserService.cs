using CnpjControl.Application.Contracts.Identity;
using CnpjControl.Domain.Models.Identity;
using CnpjControl.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CnpjControl.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");
        return users.Select(q => new User
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
    }

    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync("User");
        return new User
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}