using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await _itemRepository.GetAllItemsAsync();
        }
    }
}