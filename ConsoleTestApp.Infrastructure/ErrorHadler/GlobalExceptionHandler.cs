namespace ConsoleTestApp.Infrastructure.ErrorHadler
{
    public static class GlobalExceptionHandler
    {
        public static void Register()
        {
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            HandleException(ex);

            Environment.Exit(1);
        }

        public static void HandleException(Exception ex)
        {
            Console.WriteLine($"Произошло исключение");

            LogError(ex);
        }

        private static void LogError(Exception ex)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Ошибка: {ex.Message}\nСтек вызовов: {ex.StackTrace}\n";

            File.AppendAllText(logFilePath, logMessage);
        }
    }
}
