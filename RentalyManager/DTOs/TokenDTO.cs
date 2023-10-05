namespace RentalyManager.DTOs
{
    public class TokenDTO
    {
        public string Type { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
