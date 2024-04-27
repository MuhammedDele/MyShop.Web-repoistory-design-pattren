using Microsoft.EntityFrameworkCore;
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

        public OrderRepository(ShoppingContext context) :base(context){ }

        public override IEnumerable<Order> All()
        {
            return _context.Orders
                .Include(o => o.Orderlines)
                .ThenInclude(lineItem => lineItem.Product).ToList();
        }
        public override Order Update(Order entity)
        {
            var order = _context.Orders.Include(o => o.Orderlines)
                                       .ThenInclude(lineItem => lineItem.Product)
                                       .Single(o => o.OrderID == entity.OrderID);
            order.OrderDate = entity.OrderDate;
            order.Orderlines = entity.Orderlines;
            return base.Update(order);
        }
    }
}
