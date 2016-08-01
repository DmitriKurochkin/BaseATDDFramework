using System;
using System.Collections.Generic;
using System.Threading;

namespace AIMS.Tests.Common.TestUtil
{
    public class ActionAttempter
    {
        private List<Type> _listOfIgnoredExceptionsDuringAttempt = new List<Type>();
        public int MillisecondsTimeout { get; set; }
        public int NumberOfAttempts { get; set; }
        public bool WaitBefore { get; set; }
        public bool AnyType { get; set; }
        public List<Type> ListOfIgnoredExceptionsDuringAttempt
        {
            get { return _listOfIgnoredExceptionsDuringAttempt; }
            set { _listOfIgnoredExceptionsDuringAttempt = value; }
        }

        public Action<int> Action { get; set; }

        public void Run()
        {
            if (Action == null)
            {
                return;
            }

            if (NumberOfAttempts < 1)
            {
                NumberOfAttempts = 1;
            }

            if (WaitBefore)
            {
                Thread.Sleep(MillisecondsTimeout);
            }

            for (var i = 1; i < NumberOfAttempts + 1; i++)
            {
                try
                {
                    Action(i);
                    return;
                }
                catch (Exception e)
                {
                    if (i == NumberOfAttempts || !AnyType && !ListOfIgnoredExceptionsDuringAttempt.Contains(e.GetType()))
                    {
                        throw;
                    }
                }
                Thread.Sleep(MillisecondsTimeout);
            }
        }
    }
}