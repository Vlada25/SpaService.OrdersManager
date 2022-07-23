using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Domain.Configuration
{
    public class OrdersConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new List<Order>
            {
                new Order
                {
                    Id = new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf"),
                    ClientId = new Guid("e62c8c60-2128-4f50-ae7d-a36876ad2811"),
                    ScheduleId = new Guid("11ae77ab-8cbd-407b-bf00-ff761ba9e9f7")
                }
            });
        }
    }
}
