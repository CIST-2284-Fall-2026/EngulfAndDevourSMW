using Common.Models;

namespace Common.Interfaces
{
    public interface IRSComponentsDAL
    {
        Task<List<RSComponent>> GetAllAsync();
        Task AddAsync(RSComponent component);
        Task DeleteAsync(RSComponent component);
        Task DeleteAllAsync();
    }
}