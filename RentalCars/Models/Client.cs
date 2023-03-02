using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCars.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(10)]
        public string ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Point { get; set; }
    }
}
