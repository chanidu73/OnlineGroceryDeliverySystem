using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}
        public DbSet<DeliveryModel>Deliveries { get;set; }
        public DbSet<Location> Locations { get;set; }
    }
}