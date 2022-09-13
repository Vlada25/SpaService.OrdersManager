using OrdersManager.Domain.Models;
using SpaService.Domain.Messages.LogMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Logging
{
    public interface ILoggingService
    {
        Task SendLogMessage(Order order, OrderAction action);
    }
}
