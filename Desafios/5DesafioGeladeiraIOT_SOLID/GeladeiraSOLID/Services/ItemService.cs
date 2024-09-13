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
           return await _itemRepository.GetAllAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task<Item> GetItemByNameAsync(string name)
        {
            var item = await _itemRepository.GetByNameAsync(name);
            if (item == null)
            {
                throw new KeyNotFoundException($"Não tem o item {name} na geladeira!");
            }
            return item;
        }
        
        public async Task<IEnumerable<Item>> GetExpiredItems()
        {
            List<Item> expired = new();
            var items = await _itemRepository.GetAllAsync();
            foreach (var item in items)
            {
                if (item.Validade <= DateTime.UtcNow)
                {
                    expired.Add(item);
                }
            }
            return expired;
        }
               
        public async Task AddItemAsync(Item item)
        {
            var existingItem = await _itemRepository.GetByCombinationAsync(item.Prateleira, item.Container, item.Posicao);    
            if (existingItem != null)
            {
                throw new InvalidOperationException($"Já existe um item na prateleira {item.Prateleira}, container {item.Container} e posição {item.Posicao}.");
            }
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