using Android.Content;
using System;
using Xam.Plugin.Badger.Abstractions;

namespace Xam.Plugin.Badger.Android
{
    public class BadgerService : IBadgerService
    {
        Badge _badge;
        public BadgerService() { }
        public BadgerService(Context context = null)
        {
            if (context != null)
                _badge = new Badge(context);
        }

        public void SetAndroidContext(object context)
        {
            if (context is Context ctx)
                _badge = new Badge(ctx);
        }

        public void Decrement()
        {
            VerifyContext();
            if (_badge.Count > 0)
                _badge.SetCount(_badge.Count - 1);
        }

        public void Increment()
        {
            VerifyContext();
            _badge.Increment();
        }

        public void Reset()
        {
            VerifyContext();
            _badge.SetCount(0);
        }

        public void SetCount(int badgeCount)
        {
            VerifyContext();
            _badge.SetCount(badgeCount >= 0 ? badgeCount : 0);
        }

        void VerifyContext()
        {
            if (_badge == null)
                throw new NullReferenceException("You have to pass the android context in the non-default constructor, or set it via SetAndroidContext method");
        }
    }
}