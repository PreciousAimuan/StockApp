using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Interfaces;
using StockApp.Models;

namespace StockApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(c => c.Stock).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
