using System;

namespace AIMS.Tests.Common.TestUtil
{
    public static class Log
    {
        private const string Start = "     ";
        private const string MessageFormat = Start + "{0}: {1}";
        public static void Write(string message)
        {
            Console.WriteLine(MessageFormat, DateTime.Now, message);
        }

        public static void Write(string message, Exception e)
        {
            Write(message);
            Console.WriteLine(Start + e);
        }
    }
}
