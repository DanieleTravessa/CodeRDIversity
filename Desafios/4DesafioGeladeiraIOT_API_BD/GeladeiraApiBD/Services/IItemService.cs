using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraApiBD.Models;

namespace GeladeiraApiBD.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
    }
}
