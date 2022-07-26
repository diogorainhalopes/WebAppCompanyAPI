using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCompany.Data;
using WebAppCompany.Models;

namespace WebAppCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentDbContext _context;

        public DepartmentController(DepartmentDbContext context) => _context = context;

        // get all depts.
        [HttpGet]
        public async Task<IEnumerable<Department>> Get() => await _context.Departments.ToListAsync();
        
        // get dept by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Department), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department == null ? NotFound() : Ok(department); // 404 vs 200 response codes from ControllerBase
        }
        // create a new dpt
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = department.Id}, department);
        }

        // update a dept
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, Department department)
        {
            if (id != department.Id) return BadRequest();
            
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // delete a dept
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var departmentToDelete = await _context.Departments.FindAsync(id);
            if (departmentToDelete == null) return NotFound();

            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
