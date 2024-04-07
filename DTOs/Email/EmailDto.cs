namespace StockApp.DTOs.Email
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        /*public string Body { get; set; } = string.Empty;*/
        public string UserName { get; set; }
        public string Otp { get; set; }
    }
}
