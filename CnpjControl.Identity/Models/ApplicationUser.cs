using CnpjControl.Domain.Models.Company;
using Microsoft.AspNetCore.Identity;

namespace CnpjControl.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public ICollection<Company> Companies { get; set; }
}