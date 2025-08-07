namespace OrgStructureApi.Models;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public int ManagerId { get; set; }
    public Employee Manager { get; set; } = null!;

    public int DivisionId { get; set; }
    public Division Division { get; set; } = null!;

    public List<Department> Departments { get; set; } = new();
}