using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;

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
            modelBuilder.Entity<Order>().Property(p => p.Id).IsRequired();

            modelBuilder.Entity<Order>().Property(p => p.ScheduleId).IsRequired();

            modelBuilder.Entity<Order>().Property(p => p.ClientId).IsRequired();

            modelBuilder.Entity<Order>().Property(p => p.Status).IsRequired();

            modelBuilder.Entity<Order>().HasOne(o => o.Schedule).WithOne(s => s.Order);


            // Feedback
            modelBuilder.Entity<Feedback>().Property(p => p.Id).IsRequired();

            modelBuilder.Entity<Feedback>().Property(p => p.Mark).IsRequired();

            modelBuilder.Entity<Feedback>().Property(p => p.OrderId).IsRequired();

            modelBuilder.Entity<Feedback>().HasOne(f => f.Order).WithMany(o => o.Feedbacks);


            // Schedule
            modelBuilder.Entity<Schedule>().Property(p => p.Id).IsRequired();

            modelBuilder.Entity<Schedule>().Property(p => p.MasterId).IsRequired();

            modelBuilder.Entity<Schedule>().Property(p => p.ServiceId).IsRequired();

            modelBuilder.Entity<Schedule>().Property(p => p.StartTime).IsRequired();

            modelBuilder.Entity<Schedule>().Property(p => p.EndTime).IsRequired();



            base.OnModelCreating(modelBuilder);
        }
    }
}
