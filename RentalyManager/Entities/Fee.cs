using RentalyManager.ValueObjects;

namespace RentalyManager.Entities
{
    public class Fee
    {
        public int Id { get; set; }
        public RangeEnum Gama { get; set; }
        public decimal Pday { get; set; }
        public decimal Pkms { get; set; }
        public decimal Free { get; set; }
    }
}
