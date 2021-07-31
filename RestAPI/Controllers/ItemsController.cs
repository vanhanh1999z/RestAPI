using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPI.Models.Repositories;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Item>> GetItems()
        {
            
            return await _itemRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItems(int id)
        {
            return await _itemRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Item>>PostItems([FromBody] Item item)
        {
            var newItem = await _itemRepository.Create(item);
            return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
        }

        [HttpPut]
        public async Task<ActionResult> PutItems(int id,[FromBody] Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _itemRepository.Update(item);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete (int id)
        {
            var itemToDelete = await _itemRepository.Get(id);
            if(itemToDelete == null)
            {
                return NoContent();
            }
            await _itemRepository.Delete(itemToDelete.Id);
            return NoContent();
        }
    }
}
