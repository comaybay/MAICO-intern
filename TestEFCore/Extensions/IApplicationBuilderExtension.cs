using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEFCore.Data;
using TestEFCore.Models;

namespace TestEFCore.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static void MigrateAndSeedDb(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<IDbContextFactory<AppDbContext>>().CreateDbContext();

            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.Add(new Product()
                {
                    Name = "Squeaky Dog Bone",
                    Price = 4.99M,
                });

                context.Products.Add(new Product()
                {
                    Name = "Tenis Ball 3-Pack",
                    Price = 4.99M,
                });
            }

            context.SaveChanges();
        }
    }
}
