using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartChem.Data;

namespace SmartChem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartChemController : ControllerBase
    {
        private readonly DataContext _context;

        public SmartChemController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Element>> GetElement(int id)
        {
            var element = await _context.Elements.FindAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<Element>> GetElementByName(string name)
        {
            var element = await _context.Elements.FirstOrDefaultAsync(e => e.Name == name);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

    }
}
