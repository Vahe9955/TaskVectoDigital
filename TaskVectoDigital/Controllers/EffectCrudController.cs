using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskVectoDigital.AppContext;
using TaskVectoDigital.Models;

namespace TaskVectoDigital.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EffectCrudController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EffectCrudController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetEffects()
        {
            var products = await _context.Effects.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEffect(int id)
        {
            var effect = await _context.Effects.FindAsync(id);
            if (effect == null)
            {
                return NotFound();
            }
            return Ok(effect);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEffect(Effect model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedEffect = new Effect()
            {
                Name = model.Name,
                EffectsDescription = model.EffectsDescription,
            };

            await _context.Effects.AddAsync(addedEffect);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = addedEffect.Id }, addedEffect);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEffect(int id)
        {
            var effect = await _context.Effects.FindAsync(id);
            if (effect == null)
            {
                return NotFound();
            }

            _context.Effects.Remove(effect);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


