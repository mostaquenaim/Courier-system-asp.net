namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.CourierContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.CourierContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //Admin seed
          /*  var existingAdmin = context.Admins.FirstOrDefault(a => a.Email == "admin@example.com");

            if (existingAdmin == null)
            {
                // Admin doesn't exist, so create a new one
                context.Admins.AddOrUpdate(new Models.Admin
                {
                    Id = 1,
                    Email = "admin@example.com",
                    Password = Guid.NewGuid().ToString().Substring(0,15)
                });
            }

            var random = new Random();
            var emailDomain = (random.Next(0, 2) == 0) ? ".com" : ".co";

            //Customer seed
            for (int i=0; i<10; i++)
            {
                context.Customers.AddOrUpdate(new Models.Customer
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Email = Guid.NewGuid().ToString() + "@" + Guid.NewGuid().ToString().Substring(1, 10) + emailDomain,
                    PhoneNo = "01" + random.Next(0, 10) +
                    random.Next(0, 10) + random.Next(0, 10) + random.Next(0, 10) +
                    random.Next(0, 10) + random.Next(0, 10) + random.Next(0, 10) +
                    random.Next(0, 10) + random.Next(0, 10), // Generates a random 11-digit number starting with '01'
                    Address = Guid.NewGuid().ToString().Substring(0, 15)
                });
            }

            //Receiver seed 
            for (int i = 0; i < 10; i++)
            {
                context.Receivers.AddOrUpdate(new Models.Receiver
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Email = Guid.NewGuid().ToString() + "@" + Guid.NewGuid().ToString().Substring(1, 10) + emailDomain,
                    PhoneNo = "01" + random.Next(0, 10) +
                    random.Next(0, 10) + random.Next(0, 10) + random.Next(0, 10) +
                    random.Next(0, 10) + random.Next(0, 10) + random.Next(0, 10) +
                    random.Next(0, 10) + random.Next(0, 10), // Generates a random 11-digit number starting with '01'
                    Address = Guid.NewGuid().ToString().Substring(0, 15)
                });
            }

            //Shipper seed 
            for (int i = 0; i < 10; i++)
            {
                context.Shippers.AddOrUpdate(new Models.Shipper
                {
                    ID = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Email = Guid.NewGuid().ToString() + "@" + Guid.NewGuid().ToString().Substring(1, 10) + emailDomain,
                    Password = Guid.NewGuid().ToString().Substring(0, 15)
                });
            }

            //Status seed
            var statuses = new[]
            {
                new Status { Id = 1, Name = "Order Received" },
                new Status { Id = 2, Name = "Processing" },
                new Status { Id = 3, Name = "Out for Delivery" },
                new Status { Id = 4, Name = "Delivered" },
                new Status { Id = 5, Name = "Failed Delivery Attempt" },
                new Status { Id = 6, Name = "Return to Sender" },
                new Status { Id = 7, Name = "In Transit" },
                new Status { Id = 8, Name = "On Hold" },
                new Status { Id = 9, Name = "Exception" }
            };

            context.Statuses.AddOrUpdate(statuses);
            


            //Shipment seed 
            for (int i = 0; i < 10; i++)
            {
                // Generate a random number of days between 1 and 30 (for the next 1 month)
                int randomDays = random.Next(1, 31);

                // Calculate the EstimatedDeliveryTime by adding the random number of days to the current date
                DateTime estimatedDeliveryTime = DateTime.Now.AddDays(randomDays);

                context.Shipments.AddOrUpdate(new Models.Shipment
                {
                    Id = i,
                    ShipperId = random.Next(0, 11),
                    CustomerId = random.Next(0, 11),
                    ReceiverId = random.Next(0, 11),
                    From = Guid.NewGuid().ToString().Substring(0, 20),
                    Destination = Guid.NewGuid().ToString().Substring(0, 20),
                    EstimatedDeliveryTime = estimatedDeliveryTime, // Set the random
                    StatusId = random.Next(1, 10),

                }); 
            } */



        } 
    }
}
