using System.ComponentModel.DataAnnotations;

namespace CnpjControl.Domain.Models.Identity;

public class RegistrationRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Firstname { get; set; }
    
    [Required]
    public string Lastname { get; set; }
    
    [Required]
    [MinLength(5)]
    public string UserName { get; set; }
    
    [Required]
    [MinLength(5)]
    public string Password { get; set; }
}