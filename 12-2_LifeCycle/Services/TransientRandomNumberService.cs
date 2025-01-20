using System;

namespace _12_2_LifeCycle.Services
{
    public class TransientRandomNumberService : IRandomNumberService
    {
        private readonly int _randomNumber;

        public TransientRandomNumberService()
        {
            _randomNumber = new Random().Next(1, 1000);
        }

        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
