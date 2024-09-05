using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraApiBD.Data;
using GeladeiraApiBD.Models;
using Microsoft.EntityFrameworkCore;

namespace GeladeiraApiBD.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GeladeiraApiDbContext _context;
        
        public ItemRepository(GeladeiraApiDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Itens.ToListAsync();
        }
        
        public async Task<Item> GetByIdAsync(int id)
        {
            var itemExistente = await _context.Itens.FindAsync(id);
            if (itemExistente is null)
                return null;
            return itemExistente;
        }

        
        public async Task AddAsync(Item item)
        {
            await _context.Itens.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Item item)
        {
            _context.Itens.Update(item);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Itens.FindAsync(id);
            if (item != null)
            {
                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
