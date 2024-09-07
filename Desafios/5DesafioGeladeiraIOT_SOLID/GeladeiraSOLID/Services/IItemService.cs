using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeladeiraSOLID.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
    }
}