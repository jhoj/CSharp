using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            if (db.Database == null)
            {
                throw new Exception("DB is null");
            }
            if (db.Product.Any())
            {
                return; // DB has been seeded
            }

            //adding products
            db.Product.AddRange(
            new Product
            {

                Number = 1,
                Name = "Not Active",
                Quantity = 0
             },
            new Product
            {

                Number = 02026,
                Name = "Flogkassi - 20 kg",
                Quantity = 3
            },
            new Product
            {
                Number = 03004,
                Name = "Flot - 120 cm O370 - halv",
                Quantity = 2
            },
            new Product
            {
                Number = 03001,
                Name = "Flot - 90 cm O270",
                Quantity = 4
            },
            new Product
            {
                Number = 02033,
                Name = "Hummarakassi - (AIR300)",
                Quantity = 3
            }, 
            new Product
            {
                Number = 02340,
                Name = "Kassi - 340 litur",
                Quantity = 1
            },
            new Product
            {
                Number = 02001,
                Name = "Kassi - 20 kg",
                Quantity = 3
            });

            //adding machines
            db.AddRange(
            new Machine
            {
                Name = "Machine " + 1,
                Description = "Kinesisk maskina",
                ProductId = 2
            },
            new Machine
            {
                Name = "Machine " + 2,
                Description = "Tysk maskina",
                ProductId = 3
            },
            new Machine
            {
                Name = "Machine " + 3,
                Description = "Tysk maskina",
                ProductId = 4

            });

            db.SaveChanges();
        }
    }
}
