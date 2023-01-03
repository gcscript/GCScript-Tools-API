using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCScript_Tools_API.Data;
using GCScript_Tools_API.Models;
using GCScript_Tools_API.ViewModels;
using System;

namespace GCScript_Tools_API.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AppDataContext _context;

        public CompanyController(AppDataContext context)
        {
            _context = context;
        }

        //====================================================================================================
        //==============================================[ GET ]===============================================
        //====================================================================================================
        [HttpGet("api/v1/[controller]")]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            try
            {
                if (_context.Companies is null) return NotFound();

                var results = await _context.Companies.AsNoTracking().ToListAsync();

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
        public async Task<ActionResult<Company>> GetById(Guid id)
        {
            try
            {
                if (_context.Companies is null) return NotFound();

                var result = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

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
        public async Task<ActionResult<Company>> Post(CompanyPostViewModel model)
        {
            if (_context.Companies is null) return NotFound();

            try
            {
                var responsable = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.ResponsibleId);
                if (responsable is null) { return NotFound("Responsável não existe!"); }

                var result = new Company()
                {
                    Slug = Tools.ForSlug(model.Name),
                    Name = Tools.TreatText(model.Name),
                    PurchaseMargin = model.PurchaseMargin,
                    Responsible = responsable
                };

                await _context.Companies.AddAsync(result);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //====================================================================================================
        //===========================================[ MANY POSTS ]===========================================
        //====================================================================================================
        [HttpPost("api/v1/Companies/")]
        public async Task<ActionResult<List<Company>>> PostBulk(List<CompanyPostViewModel> models)
        {
            if (_context.Companies is null) return NotFound();

            try
            {
                var result = new List<Company>();

                foreach (var model in models)
                {
                    var responsable = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.ResponsibleId);
                    if (responsable is null) continue;

                    result.Add(new Company()
                    {
                        Slug = Tools.ForSlug(model.Name),
                        Name = Tools.TreatText(model.Name),
                        PurchaseMargin = model.PurchaseMargin,
                        Responsible = responsable
                    });
                }

                await _context.Companies.AddRangeAsync(result);
                await _context.SaveChangesAsync();

                return Ok($"{result.Count} registros foram inseridos na base de dados!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
