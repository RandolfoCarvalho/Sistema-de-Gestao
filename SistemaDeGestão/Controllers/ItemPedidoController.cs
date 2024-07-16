using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Services;


namespace SeuProjeto.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class ItemPedidoController : Controller
    {
        private readonly ItemPedidoService _itemPedidoService;

        public ItemPedidoController(ItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        // GET: api/1.0/ItemPedido
        [HttpGet]
        public async Task<IActionResult> GetItensPedido()
        {
            var result =  await _itemPedidoService.GetItensPedido();
            return Ok(result);
        }

        // GET: api/api/1.0/ItemPedido/5
        [HttpGet("{id}")]
        public IActionResult GetItemPedido(int id)
        {
            var result = _itemPedidoService.GetItemPedido(id);
            return Ok(result);
        }

        // POST: api/1.0/ItemPedido
        [HttpPost]
        public async Task PostItemPedido(ItemPedido itemPedido)
        {
            await _itemPedidoService.PostItemPedido(itemPedido);
        }
        // PUT: api/1.0/ItemPedido/5
        [HttpPut("{id}")]
        public void PutItemPedido(int id, ItemPedido itemPedido)
        {
            _itemPedidoService.PutItemPedido(id, itemPedido);

        }

        // DELETE: api/1.0/ItemPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido(int id)
        {
            await _itemPedidoService.DeleteItemPedido(id);
            return Ok("Deletado com sucesso");
        }
    }
}
