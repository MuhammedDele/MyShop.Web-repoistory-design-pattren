using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        private ShoppingContext _context;

        public OrderRepository(ShoppingContext context):base(context)
        {
        }
        
    }
}
