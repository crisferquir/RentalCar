using System.ComponentModel.DataAnnotations;

namespace RentalCars.Models
{
    public class Rent
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string ClientID { get; set; }
        public Client? Client { get; set; }

        public int DaysBooked { get; set; }
        public int DaysTotal { get; set; }
        public int CarID { get; set; }
        public Car? Car { get; set; }
        public double? Price { get; set; }

    }
}
