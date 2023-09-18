using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Interface;
using SupermarketAPI.Model;

namespace SupermarketAPI.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : Controller
    {
        private readonly IItemInterface _itemInterface;

        public ItemController(IItemInterface itemInterface)
        {
            _itemInterface = itemInterface;
        }

        [HttpGet]
        public IEnumerable<Item> Index()
        {
            var item = _itemInterface.GetItems();
            return item;
                        
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _itemInterface.Create(item);
            
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpGet("id")]
        public ActionResult GetItem(Guid id)
        {
            var item = _itemInterface.GetItem(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
            
            
        }
    }
}
