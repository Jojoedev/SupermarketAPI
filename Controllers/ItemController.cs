using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.DTOs;
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
        public IEnumerable<ItemDTO> Index()
        {
            var item = _itemInterface.GetItems().Select(x => new ItemDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category,
                Quantity = x.Quantity,
                SellingPrice = x.SellingPrice
            });
            return item;
           
        }
        [HttpGet("id")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = _itemInterface.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ItemDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Quantity = item.Quantity,
                SellingPrice = item.SellingPrice
            };


        }



        [HttpPost]
        public ActionResult<ItemDTO> Create(CreateDTO createDTO)
        {
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createDTO.Name,
                Quantity = createDTO.Quantity,
                Category = createDTO.Category,
                SellingPrice = createDTO.SellingPrice,
                
            };
            _itemInterface.Create(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, createDTO);
        }

        [HttpDelete("id")]
        public void Delete(Guid id)
        {
            var delItem = _itemInterface.Delete(id);
        }

        [HttpPut("id")]
        public ActionResult Update(UpdateDTO updateDTO, Guid id)
        {
            var updateitem = _itemInterface.GetItem(id);
            if(updateitem == null)
            {
                return NotFound();
            }

            Item item = updateitem;
            //item.Id = updateDTO.Id;
            item.Name = updateDTO.Name;
            item.Quantity = updateDTO.Quantity;
            item.SellingPrice = updateDTO.SellingPrice;
            item.Category = updateDTO.Category;

            _itemInterface.UpdateItem(item);
            return NoContent();
           }
           
       
    }
}
