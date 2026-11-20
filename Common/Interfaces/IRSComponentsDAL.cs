using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Data Access Layer interface for RSComponent database calls - get all, add, delete, delete all
    /// </summary>
    public interface IRSComponentsDAL
    {
        Task<List<RSComponent>> GetAllAsync();
        Task AddAsync(RSComponent component);
        Task DeleteAsync(RSComponent component);
        Task DeleteAllAsync();
    }
}