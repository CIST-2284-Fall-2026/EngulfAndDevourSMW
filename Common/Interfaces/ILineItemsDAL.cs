using Common.Models;

namespace Common.Interfaces
{
    public interface ILineItemsDAL
    {
        Task<List<LineItem>> GetAllAsync();
        Task AddAsync(LineItem lineItem);
        Task DeleteAsync(LineItem lineItem);
        Task DeleteAllAsync();
    }
}