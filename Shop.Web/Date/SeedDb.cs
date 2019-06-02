namespace Shop.Web.Date
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly Random random;

        public SeedDb(DataContext context)//Se le inyecta la conexion a la base de datso 
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();//Co esto es confer no se sabe si la base de datso esta creada o no

            // Add products
            if (!this.context.Products.Any())//Any() si almenos hay un registro debuelve true y si no hay registro debuelve false
            {
                this.AddProduct("AirPods", 159);
                this.AddProduct("Blackmagic eGPU Pro", 1199);
                this.AddProduct("iPad Pro", 799);
                this.AddProduct("iMac", 1398);
                this.AddProduct("iPhone X", 749);
                this.AddProduct("iWatch Series 4", 399);
                this.AddProduct("Mac Book Air", 789);
                this.AddProduct("Mac Book Pro", 1299);
                this.AddProduct("Mac Mini", 708);
                this.AddProduct("Mac Pro", 2300);
                this.AddProduct("Magic Mouse", 47);
                this.AddProduct("Magic Trackpad 2", 140);
                this.AddProduct("USB C Multiport", 145);
                this.AddProduct("Wireless Charging Pad", 67.67M);
                await this.context.SaveChangesAsync();//Guarda los cambios 
            }
        }

        private void AddProduct(string name, decimal price)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = price,
                IsAvailabe = true,
                Stock = this.random.Next(100),
            });
        }
    }
}