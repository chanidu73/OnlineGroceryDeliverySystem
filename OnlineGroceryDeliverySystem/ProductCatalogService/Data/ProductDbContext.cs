using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalogService.Models;

namespace ProductCatalogService.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {}
        public DbSet<ProductModel>Products {get;set; }
        
    }
}