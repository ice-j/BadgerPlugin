using Android.Content;
using Xam.Plugin.Badger.Abstractions;

namespace Xam.Plugin.Badger.Android
{
    public class BadgeService : IBadgerService
    {
        Badge _badge;

        public BadgeService(Context context)
        {
            _badge = new Badge(context);
        }

        public void Decrement()
        {
            if (_badge.Count > 0)
                _badge.SetCount(_badge.Count - 1);
        }

        public void Increment()
            => _badge.Increment();

        public void Reset()
            => _badge.SetCount(0);

        public void SetCount(int badgeCount)
            => _badge.SetCount(badgeCount >= 0 ? badgeCount : 0);
    }
}