using StockApp.DTOs.Stock;
using StockApp.Helper;
using StockApp.Models;

namespace StockApp.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto);
        Task<List<Stock?>> GetAllAsync(QueryObject query);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExist(int id);
    }
}
