using ConsoleTestApp.Application.Interfaces;
using ConsoleTestApp.Application.Services;
using ConsoleTestApp.Domain.Models;
using ConsoleTestApp.Infrastructure.Repository.Interface;

namespace ConsoleTestApp.Infrastructure.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly List<Product> _products;
        private readonly IShoppingCart _shoppingCart;

        public StoreRepository(List<Product> products)
        {
            _products = products;
            _shoppingCart = new ShoppingCart();
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1. Просмотр товаров");
                Console.WriteLine("2. Добавить товар в корзину");
                Console.WriteLine("3. Удалить товар из корзины");
                Console.WriteLine("4. Просмотр корзины");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите опцию: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        AddProductToCart();
                        break;
                    case "3":
                        RemoveProductFromCart();
                        break;
                    case "4":
                        _shoppingCart.ViewCart();
                        Console.WriteLine($"Общая сумма: {_shoppingCart.GetTotalPrice():C}");
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        public void ShowProducts()
        {
            Console.WriteLine("\nДоступные товары:");
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }

        public void AddProductToCart()
        {
            Console.Write("Введите ID товара для добавления в корзину: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = _products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    _shoppingCart.AddToCart(product);
                    Console.WriteLine("Товар успешно добавлен в корзину.");
                }
                else
                {
                    Console.WriteLine("Товар не найден.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите числовое значение.");
            }
        }

        public void RemoveProductFromCart()
        {
            Console.Write("Введите ID товара для удаления из корзины: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = _products.FirstOrDefault(p => p.Id == productId);

                if (product != null && _shoppingCart.HasItems(product.Id))
                {
                    _shoppingCart.RemoveFromCart(product);
                    Console.WriteLine("Товар успешно удален из корзины.");
                }
                else
                {
                    Console.WriteLine("Товар не найден.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите числовое значение.");
            }
        }
    }
}