using MyShop.Domain.Models;

namespace MyShop.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Product> ProductRepository { get; }

        void SaveChanges();
    }
}