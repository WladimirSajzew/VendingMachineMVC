using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendingMachineMVC.Data
{
    public class VendingDbContext : DbContext
    {
        public VendingDbContext(DbContextOptions<VendingDbContext> options)
              : base(options)
        {

        }

        public DbSet<VendingMachineMVC.Models.Entities.Spiral> Spirals { get; set; } = default!;

        public DbSet<VendingMachineMVC.Models.Entities.Snack> Snacks { get; set; } = default!;

        public DbSet<VendingMachineMVC.Models.Entities.Coin> Coins { get; set; } = default!;
    }
}
