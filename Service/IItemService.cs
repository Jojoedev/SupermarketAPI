using SupermarketAPI.Data;
using SupermarketAPI.Interface;
using SupermarketAPI.Model;

namespace SupermarketAPI.Service
{
    public class IItemService : IItemInterface
    {
        private readonly ApplicationDbContext _Context;

        public IItemService(ApplicationDbContext context)
        {
            _Context = context;
        }

        public void Create(Item item)
        {
            _Context.Items.Add(item);
            _Context.SaveChanges();
        }

        public Item GetItem(Guid id)
        {
            var item = _Context.Items.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }

        public IEnumerable<Item> GetItems()
        {
           return _Context.Items.ToList();
        }
    }
}
