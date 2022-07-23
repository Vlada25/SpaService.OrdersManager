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
    public class FeedbacksConfig : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasData(new List<Feedback>
            {
                new Feedback
                {
                    Id = new Guid("2afd95c0-06f6-4a4f-9395-20f17a1e6214"),
                    Comment = "Good",
                    Mark = 5,
                    OrderId = new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf")
                }
            });
        }
    }
}
