using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.ServiceRepository
{
    public interface IOrderService
    {
        Task<List<OrderDetails>> GetOrders();
        Task<List<OrderDetails>> GetOrder(string name);
    }
}
