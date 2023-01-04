using OrdersManager.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OrdersManager.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(OrderStatus status)
        {
            Type type = status.GetType();
            var enumItem = type.GetField(status.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }

        public static OrderStatus SetOrderStatus(string statusStr)
        {
            switch (statusStr)
            {
                case "Not Started":
                    return OrderStatus.NotStarted;
                case "In Process":
                    return OrderStatus.InProcess;
                case "Done":
                    return OrderStatus.Done;
                case "Canceled":
                    return OrderStatus.Canceled;
                default:
                    throw new Exception("Such status of order not found");
            }
        }
    }
}
