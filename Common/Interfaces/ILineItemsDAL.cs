using Common.Models;

namespace Common.Interfaces
{
    /// <summary>
    /// Data Access Layer interface for Line Item database calls - get all, add, delete, delete all
    /// </summary>
    public interface ILineItemsDAL
    {
        Task<List<LineItem>> GetAllAsync();
        Task AddAsync(LineItem lineItem);
        Task DeleteAsync(LineItem lineItem);
        Task DeleteAllAsync();
    }
}