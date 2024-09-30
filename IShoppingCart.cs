using System;

public interface IShoppingCart
{
    void AddToCart(Product product);
    void RemoveFromCart(Product product);
    void ViewCart();
    decimal GetTotalPrice();
}