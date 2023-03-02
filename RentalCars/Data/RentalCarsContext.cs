using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalCars.Models;

namespace RentalCars.Data
{
    public class RentalCarsContext : DbContext
    {
        public RentalCarsContext (DbContextOptions<RentalCarsContext> options)
            : base(options)
        {
        }

        public DbSet<RentalCars.Models.Car> Cars { get; set; } = default;

        public DbSet<RentalCars.Models.Client> Clients { get; set; }

        public DbSet<RentalCars.Models.Rent> Rents { get; set; }
    }
}
