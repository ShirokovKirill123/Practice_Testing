namespace Practice_7
{
    public class EventLogger
    {
        private readonly string logFilePath = "events.log";

        public void Log(string message)
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}