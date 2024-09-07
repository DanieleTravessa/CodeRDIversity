using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeladeiraSOLID.Repositories
{
    public interface IItemRepository
    {
       Task<IEnumerable<Item>> GetAllItemsAsync();
    }
}