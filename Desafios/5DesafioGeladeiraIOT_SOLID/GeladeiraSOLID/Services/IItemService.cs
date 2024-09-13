using GeladeiraSOLID.Models;

namespace GeladeiraSOLID.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task<Item> GetItemByNameAsync(string name);
        Task<IEnumerable<Item>> GetExpiredItems();
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
    }
}