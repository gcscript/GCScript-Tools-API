using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCScript_Tools_API.Data;
using GCScript_Tools_API.Models;
using GCScript_Tools_API.ViewModels;

namespace GCScript_Tools_API.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDataContext _context;

        public RoleController(AppDataContext context)
        {
            _context = context;
        }

        //====================================================================================================
        //==============================================[ GET ]===============================================
        //====================================================================================================
        [HttpGet("api/v1/[controller]")]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            try
            {
                if (_context.Roles is null) return NotFound();

                var results = await _context.Roles.AsNoTracking().ToListAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //====================================================================================================
        //===========================================[ GET BY ID ]============================================
        //====================================================================================================
        [HttpGet("api/v1/[controller]/{id:guid}")]
        public async Task<ActionResult<Role>> GetById(Guid id)
        {
            try
            {
                if (_context.Roles is null) return NotFound();

                var result = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //====================================================================================================
        //==============================================[ POST ]==============================================
        //====================================================================================================
        [HttpPost("api/v1/[controller]")]
        public async Task<ActionResult<Role>> Post(RolePostViewModel model)
        {
            if (_context.Roles is null) return NotFound();

            try
            {
                var result = new Role()
                {
                    Name = model.Name
                };

                await _context.Roles.AddAsync(result);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
