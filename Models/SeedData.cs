using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                   new Product
                   {
                       Name = "Jacket",
                       Description = "Black bomber jacket",
                       Category = "Jackets and coats",
                       Price = 150
                   },
                   new Product
                   {
                       Name = "Jeans",
                       Description = "Blue skinny jeans",
                       Category = "Trousers",
                       Price = 50
                   },
                   new Product
                   {
                       Name = "Signature T-shirt",
                       Description = "crew kneck T-shirt with logo",
                       Category = "T-shirts",
                       Price = 25
                   },
                   new Product
                   {
                       Name = "White socks",
                       Description = "Pair of white socks with logo",
                       Category = "Socks and pants",
                       Price = 8
                   },
                   new Product
                   {
                       Name = "Grey Jumper",
                       Description = "Grey Jumper pullover with logo",
                       Category = "Jumpers and cardigans",
                       Price = 45
                   },
                   new Product
                   {
                       Name = "Black hoodie",
                       Description = "Black pullover hoodie with logo",
                       Category = "Jumpers and cardigans",
                       Price = 45
                   }
                    );
                context.SaveChanges();
            }
        }
    }
}
