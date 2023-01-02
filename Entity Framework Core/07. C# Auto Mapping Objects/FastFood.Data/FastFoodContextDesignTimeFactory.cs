using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data
{
    public class FastFoodContextDesignTimeFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FastFoodContext>();
            optionsBuilder.UseSqlServer
                (@"Server=localhost;Database=BookShop;User ID=sa;Password=PavlovNik4312;TrustServerCertificate=true;");
            return new FastFoodContext(optionsBuilder.Options);
        }
    }
}
