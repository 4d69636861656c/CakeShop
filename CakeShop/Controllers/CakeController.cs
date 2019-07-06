using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Models;

namespace CakeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly Data.ApplicationDbContext _context;

        public CakeController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/cake
        [HttpPost]
        public async Task<ActionResult<Cake>> PostCakes(Cake cake)
        {
            _context.Cakes.Add(cake);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCake), new { id = cake.CakeId }, cake);
        }

        // GET: api/cakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(long id)
        {
            var cake = await _context.Cakes.FindAsync(id);

            if (cake == null)
            {
                return NotFound();
            }

            return cake;
        }
    }
}