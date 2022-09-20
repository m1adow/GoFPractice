namespace GoFPractice.GoF.Bridge
{
    interface IRegisterLog
    {
        void RegisterLog(string message);
    }

    class ConsoleLogger : IRegisterLog
    {
        public void RegisterLog(string message) => Console.WriteLine(message);
    }

    class FileLogger : IRegisterLog
    {
        public void RegisterLog(string message)
        {
            using (var streamWriter = new StreamWriter("D:\\log.txt"))
            {
                streamWriter.WriteLine(message);
            }
        }
    }

    abstract class Log
    {
        public IRegisterLog RegisterLog { get; set; }
        public string Message { get; set; }
        public abstract void LogMessage();
    }

    class ApplicationLog : Log
    {
        public override void LogMessage() => RegisterLog.RegisterLog(Message);
    }
}
