using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgStructureApi.Data;
using OrgStructureApi.Models;

namespace OrgStructureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CompaniesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _context.Companies
            .Include(c => c.Director)
            .Include(c => c.Divisions)
            .ToListAsync();
        
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var company = await _context.Companies
            .Include(c => c.Director)
            .Include(c => c.Divisions)
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return company == null ? NotFound() : Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Company company)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Company company)
    {
        if (id != company.Id) return BadRequest();
        
        _context.Entry(company).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null) return NotFound();
        
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    
    
    
    
}