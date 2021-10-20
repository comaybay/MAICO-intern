using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEFCore.Models;

namespace TestEFCore.Data
{
    public class ProductService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public ProductService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<Product[]> GetAllProductsAsync()
        {
            using var context = _dbFactory.CreateDbContext();
            return await context.Products.OrderBy(p => p.Id).ToArrayAsync();
        }

        public async Task<Response> AddNewProduct(Product product)
        {
            if (await HasProductName(product.Name))
            {
                return new Response()
                {
                    Success = false,
                    Errors = new Dictionary<string, List<string>> {
                        { nameof(Product.Name), new List<string> { $"Product '{product.Name}' already existed." } }
                    }
                };
            }

            using var context = _dbFactory.CreateDbContext();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return new Response() { Success = true };
        }

        public async Task<bool> HasProductName(string name)
        {
            using var context = _dbFactory.CreateDbContext();
            return await context.Products.Where(p => p.Name == name).AnyAsync();
        }

        public async Task RemoveProduct(int productId)
        {
            using var context = _dbFactory.CreateDbContext();
            var product = await context.Products.FindAsync(productId);

            if (product == null)
                return;

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<Response> EditProduct(Product editProduct)
        {
            using var context = _dbFactory.CreateDbContext();
            var product = await context.Products.FindAsync(editProduct.Id);

            if (product == null)
            {
                return new Response()
                {
                    Success = false,
                    Errors = new Dictionary<string, List<string>> {
                        { nameof(Product.Name), new List<string> { $"Product with id of '{editProduct.Id}' do not exist." } }
                    }
                };
            }

            product.Name = editProduct.Name;
            product.Price = editProduct.Price;

            await context.SaveChangesAsync();
            return new Response() { Success = true };
        }
    }
}
