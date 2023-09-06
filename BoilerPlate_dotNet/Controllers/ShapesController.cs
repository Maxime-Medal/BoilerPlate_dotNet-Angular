using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoilerPlate.Data;
using BoilerPlate.Models;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowOrigin")]
    [ApiController]
    public class ShapesController : ControllerBase
    {
        private readonly BoilerPlateContext _context;

        public ShapesController(BoilerPlateContext context)
        {
            _context = context;
        }

        // GET: api/Shapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shape>>> GetShape()
        {
            if (_context.Shape == null)
            {
                return NotFound();
            }
            return await _context.Shape
                .Where(s => s.FormType == "Circle" || s.FormType == "Rectangle" || s.FormType == "Text")
                .OrderBy(s => s.Order)
                .ToListAsync();
        }

        //// GET: api/Shapes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Shape>> GetShape(int id)
        //{
        //    if (_context.Shape == null)
        //    {
        //        return NotFound();
        //    }
        //    var shape = await _context.Shape.FindAsync(id);

        //    if (shape == null)
        //    {
        //        return NotFound();
        //    }

        //    return shape;
        //}

        //// PUT: api/Shapes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutShape(string id, Shape shape)
        //{
        //    if (id != shape.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(shape).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShapeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Shapes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Shape>> PostShape(Shape shape)
        //{
        //    if (_context.Shape == null)
        //    {
        //        return Problem("Entity set 'BoilerPlateContext.Shape'  is null.");
        //    }
        //    _context.Shape.Add(shape);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetShape", new { id = shape.Id }, shape);
        //}

        //// DELETE: api/Shapes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteShape(int id)
        //{
        //    if (_context.Shape == null)
        //    {
        //        return NotFound();
        //    }
        //    var shape = await _context.Shape.FindAsync(id);
        //    if (shape == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Shape.Remove(shape);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ShapeExists(string id)
        //{
        //    return (_context.Shape?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
