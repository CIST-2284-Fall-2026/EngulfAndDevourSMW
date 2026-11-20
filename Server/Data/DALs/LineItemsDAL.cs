using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Data.DALs
{
    public class LineItemsDAL : ILineItemsDAL
    {
        private readonly ApplicationDbContext context;

        public LineItemsDAL(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(LineItem lineItem)
        {
            this.context.LineItems.Add(lineItem);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            this.context.LineItems.RemoveRange(context.LineItems);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LineItem lineItem)
        {
            var item = this.context.LineItems.Where(i => i.Id == lineItem.Id).FirstOrDefault();
            if (item != null)
            {
                this.context.LineItems.Remove(lineItem);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task<List<LineItem>> GetAllAsync()
        {
            return await this.context.LineItems.ToListAsync();
        }
    }
}