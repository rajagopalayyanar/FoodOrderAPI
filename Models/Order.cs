using System;

namespace OrdersAPI.Models
{
    public class Order
    {

        public string OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string RestaurantName { get; set; }
        //public string DeliveryAddress { get; set; }
        public string OrderStatus { get; set; }
        //public string OrderItems { get; set; }
        //public double BillAmount { get; set; }
       //public string PaymentMode { get; set; }
        //public double Ratings { get; set; }

    }
}
