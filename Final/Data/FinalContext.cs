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
        public DbSet<Final.Models.WorkedAt> EmployedAts { get; set; } = default!;
        public DbSet<Final.Models.Storage> Storages { get; set; } = default!;
        public DbSet<Final.Models.Order> Orders { get; set; } = default!;
        public DbSet<Final.Models.Person> Persons { get; set; } = default!;
        public DbSet<Final.Models.OrderItem> OrderItems { get; set; } = default!;
        public DbSet<Final.Models.Refund> Refunds { get; set; } = default!;
        public DbSet<Final.Models.Retail> Retails { get; set; } = default!;
        public DbSet<Final.Models.Staff> Staffs { get; set; } = default!;
        public DbSet<Final.Models.Supplier> Suppliers { get; set; } = default!;
        public DbSet<Final.Models.Supplying> Supplyings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WorkedAt>().HasKey(table => new
            {
                table.staffId,
                table.retailId
            });

            modelBuilder.Entity<OrderItem>().HasKey(table => new
            {
                table.orderId,
                table.productId
            });


            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    supplierId = 1,
                    name = "Supplier1",
                },
                new Supplier
                {
                    supplierId = 2,
                    name = "Supplier2",
                },
                new Supplier
                {
                    supplierId = 3,
                    name = "Supplier3",
                }
             );

            modelBuilder.Entity<Customer>().HasData(
              new Customer
              {
                  customerId = 1,
                  personId = 1,

              },
              new Customer
              {
                  customerId = 2,
                  personId = 2,
              },
              new Customer
              {
                  customerId = 3,
                  personId = 3,
              }
           );


            modelBuilder.Entity<Storage>().HasData(
               new Storage
               {
                   storageId = 1,
                   productId = 1,
                   available = 500,
                   retailId = 1,

               },
               new Storage
               {
                   storageId = 2,
                   productId = 2,
                   available = 500,
                   retailId = 2,

               },
                new Storage
                {
                    storageId = 3,
                    productId = 3,
                    available = 500,
                    retailId = 3,

                }
            );


            modelBuilder.Entity<WorkedAt>().HasData(
               new WorkedAt
               {
                   retailId = 1,
                   role = "Manager",
                   staffId = 1,
                   employedSince = DateTime.Now


               },

                new WorkedAt
                {
                    retailId = 2,
                    role = "Staff",
                    staffId = 2,
                    employedSince = DateTime.Now
                },

                new WorkedAt
                {
                    retailId = 3,
                    role = "Cashier",
                    staffId = 3,
                    employedSince = DateTime.Now
                }

            );

            modelBuilder.Entity<Order>().HasData(
              new Order
              {
                  createdAt = DateTime.Now,
                  orderId = 1,
                  personId = 1,
                  subtotal = 200,
                  total = 220,
                  vat = 20
              },
              new Order
              {
                  createdAt = DateTime.Now,
                  orderId = 2,
                  personId = 2,
                  subtotal = 300,
                  total = 330,
                  vat = 30
              },
              new Order
              {
                  createdAt = DateTime.Now,
                  orderId = 3,
                  personId = 3,
                  subtotal = 400,
                  total = 440,
                  vat = 40
              }


           );

            modelBuilder.Entity<Person>().HasData(
              new Person
              {
                  address = "312, Lac Long Quan",
                  dateOfBirth = DateTime.Now,
                  email = "nbi2271@gmail.com",
                  firstName = "Neo",
                  lastName = "Nguyen",
                  gender = "Male",
                  personId = 1,
                  phone = "0944565607",
                  status = "single"
              },
              new Person
              {
                  address = "262, Lac Long Quan",
                  dateOfBirth = DateTime.Now,
                  email = "nbi6731@gmail.com",
                  firstName = "Lanh",
                  lastName = "Nguyen",
                  gender = "Male",
                  personId = 2,
                  phone = "0911967483",
                  status = "single"
              },
              new Person
              {
                  address = "458, Nguyen Huu Tho",
                  dateOfBirth = DateTime.Now,
                  email = "nbi9922@gmail.com",
                  firstName = "Bi",
                  lastName = "Nguyen",
                  gender = "Male",
                  personId = 3,
                  phone = "0817559294",
                  status = "single"
              }


              );

            modelBuilder.Entity<Product>().HasData(
                        new Product
                        {
                            categoryId = 1,
                            price = 20,
                            productId = 1,
                            productName = "lamboghini",
                        },
                        new Product
                        {
                            categoryId = 2,
                            price = 30,
                            productId = 2,
                            productName = "ferrari",
                        },
                        new Product
                        {
                            categoryId = 3,
                            price = 40,
                            productId = 3,
                            productName = "lamboghini",
                        }

                     );

            modelBuilder.Entity<OrderItem>().HasData(
   new OrderItem
   {
       countingUnit = "chiec",
       orderId = 1,
       productId = 1,
       quantity = 10,
       total = 100
   },
   new OrderItem
   {
       countingUnit = "chiec",
       orderId = 2,
       productId = 2,
       quantity = 20,
       total = 200
   },
   new OrderItem
   {
       countingUnit = "chiec",
       orderId = 3,
       productId = 3,
       quantity = 30,
       total = 300
   }
);

            modelBuilder.Entity<Refund>().HasData(
                        new Refund
                        {
                            createdAt = DateTime.Now,
                            orderId = 1,
                            productId = 1,
                            reason = "FOr no reason",
                            refundId = 1,

                        },
                        new Refund
                        {
                            createdAt = DateTime.Now,
                            orderId = 2,
                            productId = 2,
                            reason = "For no reason again!",
                            refundId = 2,

                        },
                        new Refund
                        {
                            createdAt = DateTime.Now,
                            orderId = 3,
                            productId = 3,
                            reason = "Just like it",
                            refundId = 3,

                        }

                     );

            modelBuilder.Entity<Retail>().HasData(
   new Retail
   {
       address = "156, Duong 3/2",
       name = "Retail1",
       retailId = 1,
   },
   new Retail
   {
       address = "326, Nguyen Tri Phuong",
       name = "Retail2",
       retailId = 2,
   },
   new Retail
   {
       address = "221, Hoa Hao",
       name = "Retail3",
       retailId = 3,
   }


);

            modelBuilder.Entity<Staff>().HasData(
                        new Staff
                        {
                            personId = 1,
                            staffId = 1,

                        },
                        new Staff
                        {
                            personId = 2,
                            staffId = 2,

                        },
                        new Staff
                        {
                            personId = 3,
                            staffId = 3,

                        }

                     );

            modelBuilder.Entity<Supplying>().HasData(
              new Supplying
              {
                  amount = 10,
                  arrivedAt = DateTime.Now,
                  hasArrived = false,
                  orderedAt = DateTime.Now,
                  productId = 1,
                  supplierId = 1,
                  supplyingId = 1,

              },

              new Supplying
              {
                  amount = 20,
                  arrivedAt = DateTime.Now,
                  hasArrived = true,
                  orderedAt = DateTime.Now,
                  productId = 2,
                  supplierId = 2,
                  supplyingId = 2,

              },

              new Supplying
              {
                  amount = 30,
                  arrivedAt = DateTime.Now,
                  hasArrived = false,
                  orderedAt = DateTime.Now,
                  productId = 3,
                  supplierId = 3,
                  supplyingId = 3,

              }



           );


        }
    }
}
