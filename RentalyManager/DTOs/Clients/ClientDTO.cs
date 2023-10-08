using RentalyManager.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace RentalyManager.DTOs.Clients
{
    public class ClientDTO
    {
        public string TradingName { get; set; }
        [Required]
        public string Identifier { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsPerson { get; set; }
        public FiscalEnum FiscalCondition { get; set; }
    }
}
