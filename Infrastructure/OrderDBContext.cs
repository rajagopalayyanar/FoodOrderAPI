using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrdersAPI.Models;

namespace OrdersAPI.Infrastructure
{
    public class OrderDBContext
    {
        private readonly IMongoDatabase database;
        private OrderDatabaseSettings _orderDatabaseSettings;
        public OrderDBContext(IOptions<OrderDatabaseSettings> options)
        {
            _orderDatabaseSettings = options.Value;
            MongoClientSettings clientSettings = MongoClientSettings.FromConnectionString(_orderDatabaseSettings.ConnectionString);
            MongoClient client = new MongoClient(clientSettings);
            if (client != null)
            {
                this.database = client.GetDatabase(_orderDatabaseSettings.DatabaseName.Trim());
            }
        }

        public IMongoCollection<OrderDetails> OrderDetails
        {
            get
            {
                return this.database.GetCollection<OrderDetails>("order");
            }
        }
        public IMongoCollection<Order> Order
        {
            get
            {
                return this.database.GetCollection<Order>("order");
            }
        }
    }
}
