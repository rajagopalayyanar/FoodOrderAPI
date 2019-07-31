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
        public async Task<OrderDetails> GetOrder(string orderId)
        {
            var order = await _orderDBContext.OrderDetails.FindAsync<OrderDetails>(ord => ord.id == orderId);
            return order.FirstOrDefault();
        }
        public void OrderCancel(string orderId, OrderDetails orderIn)
        {
            _orderDBContext.OrderDetails.ReplaceOne(ord => ord.id == orderId, orderIn);
        }
        public OrderDetails Create(OrderDetails order)
        {

            //var jsonData = "{\"emailId\":\"raja@g.com\",\"restaurantName\":\"ABC restaurant\",\"location\":\"Chennai\",\"deliveryAddress\":\"123, car st, chennai-600023\",\"items\":[{\"name\":\"chicken briyani\",\"price\":180,\"quantity\":2}], \"totalAmount\":360, \"paymentMode\":\"Card\"}";
            //    dynamic orderDetails = JObject.Parse(jsonData);
            //    ordDetails.EmailID = orderDetails["emailId"];
            //    ordDetails.RestaurantName = orderDetails["restaurantName"];
            //    ordDetails.OrderDateTime = DateTime.Now.ToShortDateString();
            //    ordDetails.OrderStatus = "Delivered";
            //    ordDetails.DeliveryAddress = orderDetails["deliveryAddress"];
            //    ordDetails.BillAmount = orderDetails["totalAmount"];
            //ordDetails.PaymentMode = orderDetails["restaurantName"];
            //dynamic itemDetails = orderDetails["items"];
            //List<OrderItems> ordItems = new List<OrderItems>();
            //foreach(var ord in itemDetails)
            //{
            //    ordItems.Add(
            //        new OrderItems() { ItemName=ord["name"],Price=ord["price"],Quantity=ord["quantity"]} 
            //    );
            //}
            order.OrderStatus = "Success";

             _orderDBContext.OrderDetails.InsertOne(order);
             return ordDetails;
            
            
        }
    }
}
