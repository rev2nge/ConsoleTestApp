namespace ConsoleTestApp.Infrastructure.Repository.Interface
{
    public interface IStoreRepository
    {
        void ShowMenu();
        void ShowProducts();
        void AddProductToCart();
        void RemoveProductFromCart();
    }
}