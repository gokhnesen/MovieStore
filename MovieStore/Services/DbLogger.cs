namespace MovieStore.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.Write("[DbLogger] -" + message);
        }
    }
}
