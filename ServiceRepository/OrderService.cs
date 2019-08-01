using OrdersAPI.Infrastructure;
using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace OrdersAPI.ServiceRepository
{
    public class OrderService:IOrderService
    {
        private OrderDBContext _orderDBContext;
        private OrderDetails ordDetails;
        public OrderService(OrderDBContext orderDBContext)
        {
            ordDetails = new OrderDetails();
            _orderDBContext = orderDBContext;
        }
        public async Task<List<OrderDetails>> GetOrders()
        {
            var orders = await _orderDBContext.OrderDetails.FindAsync(order => true);
            return orders.ToList();
        }
        public async Task<List<OrderDetails>> GetOrder(string orderemailId)
        {
            var order = await _orderDBContext.OrderDetails.FindAsync<OrderDetails>(ord => ord.EmailID == orderemailId);
            return order.ToList();
        }
        public void OrderCancel(string orderId, OrderDetails orderIn)
        {
            _orderDBContext.OrderDetails.ReplaceOne(ord => ord.id == orderId, orderIn);
        }
        public OrderDetails Create(OrderDetails order)
        {
            order.OrderStatus = "Success";

            _orderDBContext.OrderDetails.InsertOne(order);
            return order;
        }
    }
}
