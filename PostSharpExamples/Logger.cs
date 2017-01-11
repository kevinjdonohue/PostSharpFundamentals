using System.Collections.Generic;
using System.Security.Policy;

namespace PostSharpExamples
{
    public static class Logger
    {
        //private static List<string> _messages;
        private static Queue<string> _messages;

        //public static List<string> Messages
        //{
        //    get { return _messages; }
        //    set { _messages = value; }
        //}

        public static Queue<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        static Logger()
        {
            //_messages = new List<string>();
            _messages = new Queue<string>();
        }

        public static void LogMessage(string message)
        {
            _messages.Enqueue(message);
        }
    }
}