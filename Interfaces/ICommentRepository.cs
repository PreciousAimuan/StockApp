using StockApp.Models;

namespace StockApp.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment> GetByIdAsync(int id);
    }
}
