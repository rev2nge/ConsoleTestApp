using ConsoleTestApp.Domain.Models;
using ConsoleTestApp.Infrastructure.Repository.Interface;
using System.Text.Json;

namespace ConsoleTestApp.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> LoadProducts(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл с товарами не найден.", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(jsonData);

            return products ?? new List<Product>();
        }
    }
}