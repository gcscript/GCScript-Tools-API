using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCScript_Tools_API.Data;
using GCScript_Tools_API.Models;
using GCScript_Tools_API.ViewModels;

namespace GCScript_Tools_API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDataContext _context;

        public UserController(AppDataContext context)
        {
            _context = context;
        }

        //====================================================================================================
        //==============================================[ GET ]===============================================
        //====================================================================================================
        [HttpGet("api/v1/[controller]")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                if (_context.Users is null) return NotFound();

                var results = await _context.Users.AsNoTracking().ToListAsync();

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
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            try
            {
                if (_context.Users is null) return NotFound();

                var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

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
        public async Task<ActionResult<User>> Post(UserPostViewModel model)
        {
            if (_context.Users is null) return NotFound();

            try
            {
                var result = new User()
                {
                    Username = model.Username,
                    Password = model.Password,
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                };

                await _context.Users.AddAsync(result);
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
