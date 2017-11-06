using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android
{
    internal abstract class BaseBadge
    {
        static BaseBadge mBadge;
        protected static Context mContext;
        protected static int CurrentCount = 0;

        static string LOG_TAG = "BadgeImplementation";

        internal abstract void SetCount(int badgeCount);
        internal abstract List<string> GetSupportLaunchers();

        internal virtual int GetCount()
            => CurrentCount;

        internal virtual void Increment()
            => SetCount(CurrentCount + 1);

        internal BaseBadge(Context context)
        {
            mContext = context;
        }

        protected String GetEntryActivityName()
        {
            ComponentName componentName = mContext.PackageManager.GetLaunchIntentForPackage(mContext.PackageName).Component;
            return componentName.ClassName;
        }

        protected String GetContextPackageName()
        {
            return mContext.PackageName;
        }
    }
}