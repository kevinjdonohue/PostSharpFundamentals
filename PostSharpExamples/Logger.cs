using System.Collections.Generic;

namespace PostSharpExamples
{
    public static class Logger
    {
        public static Queue<string> Messages { get; set; }

        static Logger()
        {
            Messages = new Queue<string>();
        }

        public static void LogMessage(string message)
        {
            Messages.Enqueue(message);
        }
    }
}