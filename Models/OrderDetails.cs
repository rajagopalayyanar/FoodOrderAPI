using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace OrdersAPI.Models
{
    public class OrderDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string EmailID { get; set; }
        public string OrderDateTime { get; set; }
        public string RestaurantName { get; set; }
        public string OrderStatus { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public double BillAmount { get; set; }
        public string PaymentMode { get; set; }
    }

    public class OrderItems
    {
        public string ItemName{ get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}