using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GeladeiraSOLID.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GeladeiraSOLIDContext _context;

        public ItemRepository(GeladeiraSOLIDContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }


    }
}