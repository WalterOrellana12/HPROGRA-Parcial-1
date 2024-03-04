using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using walterParcial1.Models;

    public class CarContext : DbContext
    {
        public CarContext (DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<walterParcial1.Models.Car> Car { get; set; } = default!;

public DbSet<walterParcial1.Models.CarBrand> CarBrand { get; set; } = default!;
}
