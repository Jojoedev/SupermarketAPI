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

        public Item Delete(Guid id)
        {
          var delItem =   _Context.Items.Where(x => x.Id == id).FirstOrDefault();
           if(delItem != null)
            {
                _Context.Remove(delItem);
                _Context.SaveChanges();
            }
            return null;
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

        public void UpdateItem(Item item)
        {
            var updateItem = _Context.Items.FirstOrDefault(x => x.Id == item.Id);
                        
            _Context.Items.Update(updateItem);
            _Context.SaveChanges();
           
           
        }
    }
}
