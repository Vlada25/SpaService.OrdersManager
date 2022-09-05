using OrdersManager.Domain.Models;
using OrdersManager.Domain.Models.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Logging
{
    public interface IHttpLoggingService
    {
        void CreateLogMessage(Order order, OrderAction action);
    }
}
