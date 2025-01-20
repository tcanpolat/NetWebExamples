using _12_2_LifeCycle.Services;

namespace _12_2_LifeCycle.Helpers
{
    public class ScopedHelperService
    {
        private readonly ScopedRandomNumberService _scopedService;

        public ScopedHelperService(ScopedRandomNumberService scopedService)
        {
            _scopedService = scopedService;
        }

        public int GetScopedNumber()
        {
            return _scopedService.GetRandomNumber();
        }
    }
}
