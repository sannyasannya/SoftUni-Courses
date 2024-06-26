﻿
namespace GetGreeting
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime GetCurrentTime()
        {
            // ако искам приложението да е работещо
           return DateTime.Now;
        }
    }

    public class FakeTimeProvider : ITimeProvider
    {
        private DateTime _fakeTime;
        public FakeTimeProvider(DateTime fakeTime)
        {
            _fakeTime = fakeTime;
        }
        public DateTime GetCurrentTime() 
        { 
            return _fakeTime;
        }
    }
}
