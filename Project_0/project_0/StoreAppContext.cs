using Microsoft.EntityFrameworkCore;
using System;

namespace project_0
{
    public class StoreAppContext : DbContext
    {
        public DbSet<Product> products {get; set;}
        public DbSet<Customer> customers {get; set;}
        public DbSet<Orders> orders {get; set;}
        public DbSet<Item> ItemsAtStore {get; set;}
        public DbSet<OrderedItem> orderedItems {get; set;}
        public DbSet<Store> stores {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LocalHost\\SQLEXPRESS01;Database=Project_0_StoreApp;Trusted_Connection=True;");
        }

    }
}