using System;
using System.Threading;
using AIMS.Tests.Common.UI;

namespace AIMS.Tests.Common.TestUtil
{
    public static class Waiter
    {
        public static void WaitUpTo(int milliseconds, Func<bool> condition, string errorMessage, int threadSleep = 100)
        {
            var timeElapsed = 0;
            var environmentTimeStart = DateTime.Now;
            var environmentTimeElapsed = new TimeSpan();

            Log.Write("Start waiting: " + errorMessage);

            var result = condition();
            while (!result && timeElapsed < milliseconds)
            {
                result = condition();
                Thread.Sleep(threadSleep);
                timeElapsed += threadSleep;
                environmentTimeElapsed = DateTime.Now - environmentTimeStart;
                if (environmentTimeElapsed.TotalMilliseconds > milliseconds)
                    break;
            }

            Log.Write("Stop waiting: " + errorMessage + ". Time elapsed - " + environmentTimeElapsed.TotalMinutes + " minutes.");

            if (timeElapsed >= milliseconds && !result ||
                environmentTimeElapsed.TotalMilliseconds >= milliseconds && !result)
                throw new UiException(string.Format("Error waiting timeout: {0}. Time elapsed - {1}", errorMessage, environmentTimeElapsed.TotalMinutes));
        }
    }
}