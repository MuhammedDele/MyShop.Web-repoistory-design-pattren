using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        private readonly ShoppingContext _shoppingContext;
        public CustomerRepository(ShoppingContext shoppingContext):base(shoppingContext) { }

        public override Customer Update(Customer entity)
        {
            var customer = _context.Customers.Single( c => c.CustomerID == entity.CustomerID);
            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.Country = entity.Country;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.PostalCode = entity.PostalCode;
            return base.Update(customer);
        }
    }

    
}
