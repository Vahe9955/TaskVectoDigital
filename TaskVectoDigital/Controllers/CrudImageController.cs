using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskVectoDigital.Models;
using TaskVectoDigital.AppContext;

namespace TaskVectoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudImageController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CrudImageController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            var images = await _context.Images.ToListAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult<ImageResponseModel>> CreateImage(Image model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var addedImage = new Image()
            {
                Name = model.Name,
                Effects = model.Effects,
            };

            await _context.Images.AddAsync(addedImage);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new ImageResponseModel { Id = addedImage.Id }, addedImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Image product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = await _context.Images.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            data = new Image()
            {
                Name = product.Name,
                Effects = product.Effects,
            };

            _context.Images.Update(data);

            await _context.SaveChangesAsync();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Images.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Images.Remove(product);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

