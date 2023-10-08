using RentalyManager.ValueObjects;

namespace RentalyManager.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public int RentId { get; set; }
        public IssueEnum Type { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public Rent Rent { get; set; }
    }
}
