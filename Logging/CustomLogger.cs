namespace Fiap.Web.Challenge.Logging
{

    public interface ICustomLogger
    {
        void Log(string message);
        
    }
    public class MockLogger : ICustomLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    partial class FileLogger : ICustomLogger
    {
        public void Log(string message)
        {
            Console.WriteLine("File:", message);
        }
    }


}
