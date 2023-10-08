using RentalyManager.ValueObjects;

namespace RentalyManager.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public DateOnly Model { get; set; }
        public string Identifier { get; set; }
        public RangeEnum Gama { get; set; }
        public bool Available { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
