using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCScript_Tools_API.Data;
using GCScript_Tools_API.Models;
using GCScript_Tools_API.ViewModels;
using System;

namespace GCScript_Tools_API.Controllers;

[ApiController]
public class OperatorController : ControllerBase
{
    private readonly AppDataContext _context;

    public OperatorController(AppDataContext context)
    {
        _context = context;
    }

    //====================================================================================================
    //==============================================[ GET ]===============================================
    //====================================================================================================
    [HttpGet("api/v1/[controller]")]
    public async Task<ActionResult<IEnumerable<Operator>>> Get()
    {
        try
        {
            if (_context.Operators is null) return NotFound();

            var results = await _context.Operators.AsNoTracking().ToListAsync();

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
    public async Task<ActionResult<Operator>> GetById(Guid id)
    {
        try
        {
            if (_context.Operators is null) return NotFound();

            var result = await _context.Operators.FirstOrDefaultAsync(x => x.Id == id);

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
    public async Task<ActionResult<Operator>> Post(OperatorPostViewModel model)
    {
        if (_context.Operators is null) return NotFound();

        try
        {
            var result = new Operator()
            {
                Slug = Tools.ForSlug(model.Name),
                Name = Tools.TreatText(model.Name),
                UF = model.UF,
                Phone = model.Phone,
                Email = model.Email,
                Site = model.Site
            };

            await _context.Operators.AddAsync(result);
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
    [HttpPost("api/v1/Operators/")]
    public async Task<ActionResult<List<Operator>>> PostBulk(List<OperatorPostViewModel> models)
    {
        if (_context.Operators is null) return NotFound();

        try
        {
            var result = new List<Operator>();

            foreach (var model in models)
            {
                result.Add(new Operator()
                {
                    Slug = Tools.ForSlug(model.Name),
                    Name = Tools.TreatText(model.Name),
                    UF = model.UF,
                    Phone= model.Phone,
                    Email= model.Email,
                    Site= model.Site
                });
            }

            await _context.Operators.AddRangeAsync(result);
            await _context.SaveChangesAsync();

            return Ok($"{result.Count} registros foram inseridos na base de dados!");
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
