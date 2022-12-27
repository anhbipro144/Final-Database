using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final.Models;

namespace Final.Data
{
    public class FinalContext : DbContext
    {
        public FinalContext(DbContextOptions<FinalContext> options)
            : base(options)
        {
        }

        public DbSet<Final.Models.Product> Product { get; set; } = default!;
        public DbSet<Final.Models.Customer> Customers { get; set; } = default!;
        public DbSet<Final.Models.EmployedAt> EmployedAts { get; set; } = default!;
        public DbSet<Final.Models.Inventory> Inventories { get; set; } = default!;
        public DbSet<Final.Models.Order> Orders { get; set; } = default!;
        public DbSet<Final.Models.Person> Persons { get; set; } = default!;
        public DbSet<Final.Models.Product_Order> Product_Orders { get; set; } = default!;
        public DbSet<Final.Models.Refund> Refunds { get; set; } = default!;
        public DbSet<Final.Models.RetailChain> RetailChains { get; set; } = default!;
        public DbSet<Final.Models.Staff> Staffs { get; set; } = default!;
        public DbSet<Final.Models.Supplier> Suppliers { get; set; } = default!;
        public DbSet<Final.Models.Supplying> Supplyings { get; set; } = default!;
    }
}
