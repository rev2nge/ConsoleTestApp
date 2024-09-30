using ConsoleTestApp.Domain.Models;

namespace ConsoleTestApp.Application.Interfaces
{
    public interface IShoppingCart
    {
        void AddToCart(Product product);
        void RemoveFromCart(Product product);
        void ViewCart();
        decimal GetTotalPrice();
        bool HasItems(int productId);
    }
}