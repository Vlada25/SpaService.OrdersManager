﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.DTO.Order
{
    public class OrderForUpdateDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ScheduleId { get; set; }
    }
}