using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Data.DALs
{
    public class RSComponentsDAL : IRSComponentsDAL
    {
        private readonly ApplicationDbContext context;

        public RSComponentsDAL(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(RSComponent component)
        {
            this.context.ReserveStudyComponents.Add(component);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            this.context.ReserveStudyComponents.RemoveRange(context.ReserveStudyComponents);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RSComponent component)
        {
            var item = this.context.ReserveStudyComponents.Where(i => i.Id == component.Id).FirstOrDefault();
            if (item != null)
            {
                this.context.ReserveStudyComponents.Remove(component);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task<List<RSComponent>> GetAllAsync()
        {
            return await this.context.ReserveStudyComponents.ToListAsync();
        }
    }
}