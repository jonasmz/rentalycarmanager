using RentalyManager.ValueObjects;

namespace RentalyManager.DTOs.Vehicles
{
    public class VehicleDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public DateOnly Model { get; set; }
        public string Identifier { get; set; }
        public RangeEnum Gama { get; set; }
        public bool Available { get; set; }
        public bool IsActive { get; set; }
    }
}
