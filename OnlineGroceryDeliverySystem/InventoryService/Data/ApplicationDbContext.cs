using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {}
        public DbSet<InventoryItem>InventoryItems { get;set; }
        public DbSet<InventoryAdjustment>InventoryAdjustments { get;set; }
    }
}