using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraSOLID.Models;
using GeladeiraSOLID.Repositories;

namespace GeladeiraSOLID.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            IEnumerable.
            var items = await _itemRepository.GetAllAsync();
            foreach (var item in items)
            {
                if (item.Validade.Date <= DateTime.Now.Date)
                {
                    item.Valido = false;
                }
            }
            return items;
            return await _itemRepository.GetAllAsync();
        }
/* 

*/
        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }
        
        public async Task AddItemAsync(Item item)
        {
            await _itemRepository.AddAsync(item);
        }
        
        public async Task UpdateItemAsync(Item item)
        {
            await _itemRepository.UpdateAsync(item);
        }
        
        public async Task DeleteItemAsync(int id)
        {
            await _itemRepository.DeleteAsync(id);
        }
    }
}