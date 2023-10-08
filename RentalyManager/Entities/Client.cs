using RentalyManager.ValueObjects;

namespace RentalyManager.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string TradingName { get; set; }
        public string Identifier { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsPerson { get; set; }
        public FiscalEnum FiscalCondition { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
