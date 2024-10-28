using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OMAContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Customer>().HasData(
            new Customer 
            {
                Id = 1,
                Firstname = "Moahmed",
                Lastname = "Ahmed",
                ContactName = "Aboulmagd",
                IsDeleted = false,
                Email = "Aboulmagd@live.com"
            },
            new Customer 
            {
                Id = 2,
                Firstname = "Shihab",
                Lastname = "Ali",
                ContactName = "Ahmed",
                IsDeleted = false,
                Email = "Shihab@live.com"
            }
           );


           modelBuilder.Entity<Address>().HasData(
            new Address 
            {
                Id = 1,
                CustomerId = 1,
                AddressLine1 = "someplaces",
                AddressLine2 = "there",
                City = "Riyadh",
                State = "SaudiArabia",
                Country = "SA"
            },
            new Address 
            {
                Id = 2,
                CustomerId = 2,
                AddressLine1 = "Another place",
                AddressLine2 = "here",
                City = "Jedah",
                State = "SaudiArabia",
                Country = "SA"
            }
           );

                modelBuilder.Entity<Order>().HasData(
            new Order 
            {
               Id = 1,
                CustomerId = 1,
                OrderDate = new DateTime(2022, 11, 10),
                Description = "new Item 1",
                TotalAmount = 1500,
                DepositeAmount = 100,
                IsDelivery = true,
                Status = Core.Enums.Status.Pending,
                OtherNotes = "somthing new",
                IsDeleted = false,
            },
            new Order 
            {
                Id = 2,
                CustomerId = 2,
                OrderDate = new DateTime(2022, 10, 20),
                Description = "new Item 2",
                TotalAmount = 500,
                DepositeAmount = 10,
                IsDelivery = true,
                Status = Core.Enums.Status.Pending,
                OtherNotes = "somthing new",
                IsDeleted = false,
            }
           );
        }
    }
}