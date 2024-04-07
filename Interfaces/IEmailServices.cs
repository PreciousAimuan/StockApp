using StockApp.DTOs.Email;

namespace StockApp.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmailRegistration(EmailDto request);
    }
}
