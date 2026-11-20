using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Data.DALs
{
    /// <summary>
    /// Data Access Layer for the Reserve Study Components Table in the database
    /// </summary>
    public class RSComponentsDAL : IRSComponentsDAL
    {
        /// <summary>
        /// Injecting the DB Context
        /// </summary>
        private readonly ApplicationDbContext context;

        public RSComponentsDAL(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Adds a component to the database table
        /// </summary>
        /// <param name="component">Component to add</param>
        public async Task AddAsync(RSComponent component)
        {
            this.context.ReserveStudyComponents.Add(component);
            await this.context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes the contents of the database table
        /// </summary>
        public async Task DeleteAllAsync()
        {
            this.context.ReserveStudyComponents.RemoveRange(context.ReserveStudyComponents);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes a component from the database table
        /// </summary>
        /// <param name="component">Component to delete</param>
        public async Task DeleteAsync(RSComponent component)
        {
            var item = this.context.ReserveStudyComponents.Where(i => i.Id == component.Id).FirstOrDefault();
            if (item != null)
            {
                this.context.ReserveStudyComponents.Remove(component);
            }
            await this.context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets the contents of the RSComponent database table
        /// </summary>
        /// <returns>Returns a list of components</returns>
        public async Task<List<RSComponent>> GetAllAsync()
        {
            return await this.context.ReserveStudyComponents.ToListAsync();
        }
    }
}