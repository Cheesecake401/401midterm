using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypts_And_Coders.Models.Services
{
    public class ItemRepository : IItem
    {
        private CryptsDbContext _context;

        public ItemRepository(CryptsDbContext context)
        {
            _context = context;
        }

        public async Task<Item> Create(Item item)
        {
            _context.Entry(item).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            Item item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Item>> GetItems()
        {
            List<Item> result = await _context.Item.ToListAsync();
            return result;
        }

        public async Task<Item> GetItem(int id)
        {
            var result = await _context.Item.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Item> Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}