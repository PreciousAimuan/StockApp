using StockApp.Models;

namespace StockApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
