namespace RentalyManager.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Dinit { get; set; }
        public DateTime Dfinish { get; set; }
        public DateTime Dreturn { get; set; }
        public decimal Kms { get; set; }
        public decimal OilMissing { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public ICollection<Issue> Issues { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
