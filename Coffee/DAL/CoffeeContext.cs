using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Coffee.Models;
namespace Coffee.DAL
{
    public class CoffeeContext : DbContext

    {
        public CoffeeContext () : base("CoffeeContext")
        {

        }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { set; get; } 
        public DbSet<User> Users { set; get; }
    }
}