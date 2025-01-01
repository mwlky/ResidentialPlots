using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public int Name { get; set; }
}