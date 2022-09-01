using Microsoft.EntityFrameworkCore;
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
            // Order
            modelBuilder.Entity<Order>().Property(p => p.Id)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Order>().Property(p => p.ScheduleId)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Order>().Property(p => p.ClientId)
                .IsRequired().HasMaxLength(36);


            // Feedback
            modelBuilder.Entity<Feedback>().Property(p => p.Id)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Feedback>().Property(p => p.Mark).IsRequired();

            modelBuilder.Entity<Feedback>().Property(p => p.OrderId)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Feedback>().HasOne(f => f.Order);


            // Schedule
            modelBuilder.Entity<Schedule>().Property(p => p.Id)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Schedule>().Property(p => p.MasterId)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Schedule>().Property(p => p.ServiceId)
                .IsRequired().HasMaxLength(36);

            modelBuilder.Entity<Schedule>().Property(p => p.StartTime).IsRequired();

            modelBuilder.Entity<Schedule>().Property(p => p.EndTime).IsRequired();

            modelBuilder.Entity<Schedule>().Property(p => p.Status).IsRequired();



            base.OnModelCreating(modelBuilder);
        }
    }
}
