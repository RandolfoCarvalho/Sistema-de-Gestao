using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;


namespace SeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : Controller
    {
        private readonly DataBaseContext _context;

        public ItemPedidoController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/ItemPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItensPedido()
        {
            return await _context.ItensPedido.ToListAsync();
        }

        // GET: api/ItemPedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetItemPedido(int id)
        {
            var itemPedido = await _context.ItensPedido.FindAsync(id);

            if (itemPedido == null)
            {
                return NotFound();
            }

            return itemPedido;
        }

        // POST: api/ItemPedido
        [HttpPost]
        public async Task<ActionResult<ItemPedido>> PostItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedido.Add(itemPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemPedido), new { id = itemPedido.Id }, itemPedido);
        }

        // PUT: api/ItemPedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPedido(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ItemPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido(int id)
        {
            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            _context.ItensPedido.Remove(itemPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItensPedido.Any(e => e.Id == id);
        }
    }
}
