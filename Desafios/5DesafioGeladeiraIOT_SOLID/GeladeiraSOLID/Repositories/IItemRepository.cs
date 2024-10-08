using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraSOLID.Data;
using GeladeiraSOLID.Models;

namespace GeladeiraSOLID.Repositories
{
    public interface IItemRepository
    {
       Task<IEnumerable<Item>> GetAllAsync();
       Task<Item> GetByIdAsync(int id);
       Task<Item> GetByNameAsync(string name);
       Task AddAsync(Item item);
       Task UpdateAsync(Item item);
       Task DeleteAsync(int id);
       Task<Item> GetByCombinationAsync(int prateleira, int container, int posicao);
    }
}