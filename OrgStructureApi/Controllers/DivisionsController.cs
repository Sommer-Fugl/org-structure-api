using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgStructureApi.Data;
using OrgStructureApi.Models;

namespace OrgStructureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DivisionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DivisionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var divisions = await _context.Divisions
            .Include(d => d.Manager)
            .Include(d => d.Projects)
            .ToListAsync();
        
        return Ok(divisions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var  division = await _context.Divisions
            .Include(d => d.Manager)
            .Include(d => d.Projects)
            .FirstOrDefaultAsync(d => d.Id == id);
        
        return Ok(division);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Division division)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _context.Divisions.Add(division);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = division.Id }, division);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Division division)
    {
        if (id != division.Id) return BadRequest();
        
        _context.Entry(division).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var division = await _context.Divisions.FindAsync(id);
        if (division == null) return NotFound();
        
        _context.Divisions.Remove(division);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}