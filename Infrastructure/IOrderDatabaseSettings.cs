using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.Infrastructure
{
    public interface IOrderDatabaseSettings
    {
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
    }
}
