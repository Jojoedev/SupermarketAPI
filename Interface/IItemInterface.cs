﻿using SupermarketAPI.Model;

namespace SupermarketAPI.Interface
{
    public interface IItemInterface
    {
        IEnumerable<Item> GetItems();
        
        void Create(Item item);

        Item GetItem(Guid id);
    }
}
