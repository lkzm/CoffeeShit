namespace Coffee.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Coffee.DAL.CoffeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Coffee.DAL.CoffeeContext context)
        {
            context.Drinks.AddOrUpdate(new Models.Drink
            {
                Price = 2.3,
                Name = "Kafe",
                Rec = "V kafevarkata"
                
            });
            context.Drinks.AddOrUpdate(new Models.Drink
            {
                Price = 4.20,
                Name = "Chaiche",
                Rec = "Chai i voda"

            });
            context.Users.AddOrUpdate(new Models.User
            {
                Username = "kur",
                Typer = 1,
                Orders = new List<Models.Order>()
               


            });

            context.SaveChanges();
        }
    }
}
