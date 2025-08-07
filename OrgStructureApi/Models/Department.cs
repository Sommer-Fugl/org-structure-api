namespace OrgStructureApi.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public int ManagerId { get; set; }
    public Employee Manager { get; set; } = null!;

    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}