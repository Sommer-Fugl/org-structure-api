namespace OrgStructureApi.Models;

public class Company
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public int DirectorId { get; set; }
    public Employee Director { get; set; } = null!;

    public List<Division> Divisions { get; set; } = new();
}