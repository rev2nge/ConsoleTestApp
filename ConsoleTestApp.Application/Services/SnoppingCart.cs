using ConsoleTestApp.Application.Interfaces;
using ConsoleTestApp.Domain.Models;

namespace ConsoleTestApp.Application.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<Product> _productsInCart = new List<Product>();

        public void AddToCart(Product product)
        {
            _productsInCart.Add(product);
            Console.WriteLine($"{product.Name} добавлен в корзину.");
        }

        public void RemoveFromCart(Product product)
        {
            if (_productsInCart.Remove(product))
            {
                Console.WriteLine($"{product.Name} удалён из корзины.");
            }
            else
            {
                Console.WriteLine("Товар не найден в корзине.");
            }
        }

        public void ViewCart()
        {
            if (CartIsEmpty())
            {
                Console.WriteLine("Корзина пуста.");
            }
            else
            {
                Console.WriteLine("Товары в корзине:");
                foreach (var product in _productsInCart)
                {
                    Console.WriteLine(product);
                }
            }
        }

        private bool CartIsEmpty()
        {
            return _productsInCart.Count == 0;
        }

        public decimal GetTotalPrice()
        {
            return _productsInCart.Sum(p => p.Price);
        }

        public bool HasItems(int productId)
        {
            return _productsInCart.Any(i => i.Id == productId);
        }
    }
}