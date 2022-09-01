using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Configuration;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database
{
    public class OrdersManagerDbContext : DbContext
    {
        public OrdersManagerDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
