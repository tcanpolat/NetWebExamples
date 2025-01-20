using System;

namespace _12_2_LifeCycle.Services
{
    public class SingletonRandomNumberService : IRandomNumberService
    {
        private readonly int _randomNumber;

        public SingletonRandomNumberService()
        {
            _randomNumber = new Random().Next(1, 1000);
        }

        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
