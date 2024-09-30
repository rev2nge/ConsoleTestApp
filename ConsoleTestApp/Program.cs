using ConsoleTestApp.Infrastructure.ErrorHadler;
using ConsoleTestApp.Infrastructure.Repository;

class Program
{
    static void Main(string[] args)
    {
        GlobalExceptionHandler.Register();

        try
        {
            RunApplication();
        }
        catch (Exception ex)
        {
            GlobalExceptionHandler.HandleException(ex);
        }
    }

    static void RunApplication()
    {
        var productRepo = new ProductRepository();
        var products = productRepo.LoadProducts("products.json");

        var store = new StoreRepository(products);
        store.ShowMenu();
    }
}