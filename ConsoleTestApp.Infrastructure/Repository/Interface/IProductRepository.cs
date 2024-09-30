using ConsoleTestApp.Domain.Models;

namespace ConsoleTestApp.Infrastructure.Repository.Interface
{
    public interface IProductRepository
    {
        List<Product> LoadProducts(string filePath);
    }
}
