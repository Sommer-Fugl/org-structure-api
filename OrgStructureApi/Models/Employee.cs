using System.ComponentModel.DataAnnotations;

namespace OrgStructureApi.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;
    
    [Phone]
    public string Phone { get; set; } = null!;
    
    [EmailAddress]
    public string Email { get; set; } = null!;
}