using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraSOLID.Models;
using GeladeiraSOLID.Data;
using Microsoft.EntityFrameworkCore;

namespace GeladeiraSOLID.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GeladeiraSOLIDContext _context;

        public ItemRepository(GeladeiraSOLIDContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var existedItem = await _context.Items.FindAsync(id);
            if (existedItem is null)
                return null;
            return existedItem;
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}