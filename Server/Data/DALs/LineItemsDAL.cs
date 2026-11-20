using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Data.DALs
{
    /// <summary>
    /// Data Access Layer for the Line Items Table in the database
    /// </summary>
    public class LineItemsDAL : ILineItemsDAL
    {
        /// <summary>
        /// Injecting the DBContext
        /// </summary>
        private readonly ApplicationDbContext context;

        public LineItemsDAL(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Adds a line item to the database table
        /// </summary>
        /// <param name="lineItem">Line Item to be added</param>
        public async Task AddAsync(LineItem lineItem)
        {
            this.context.LineItems.Add(lineItem);
            await this.context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes all items in the table
        /// </summary>
        public async Task DeleteAllAsync()
        {
            this.context.LineItems.RemoveRange(context.LineItems);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes an item from the database table
        /// </summary>
        /// <param name="lineItem">Line item to be deleted</param>
        public async Task DeleteAsync(LineItem lineItem)
        {
            // Finds the item with the matching id. If no matching item is found, no item is removed
            var item = this.context.LineItems.Where(i => i.Id == lineItem.Id).FirstOrDefault();
            if (item != null)
            {
                this.context.LineItems.Remove(lineItem);
            }
            await this.context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets all items from the database table
        /// </summary>
        /// <returns>Returns a list of line items</returns>
        public async Task<List<LineItem>> GetAllAsync()
        {
            return await this.context.LineItems.ToListAsync();
        }
    }
}