using System.ComponentModel.DataAnnotations;

namespace RentalCars.Models
{

    public class Car
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string NameCar { get; set; }
        [RegularExpression("^SUV|Small|Premium$")]
        [MaxLength(7)]
        public string TypeCar { get; set; }
        public bool Rented { get; set; }


    }
}
