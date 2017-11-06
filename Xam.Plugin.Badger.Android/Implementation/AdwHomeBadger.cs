using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class AdwHomeBadger : BaseBadge
    {
        public static String INTENT_UPDATE_COUNTER = "org.adw.launcher.counter.SEND";
        public static String PACKAGENAME = "PNAME";
        public static String COUNT = "COUNT";

        internal AdwHomeBadger(Context context) : base(context)
        {
        }

        internal override void SetCount(int badgeCount)
        {
            CurrentCount = badgeCount;
            Intent intent = new Intent(INTENT_UPDATE_COUNTER);
            intent.PutExtra(PACKAGENAME, getContextPackageName());
            intent.PutExtra(COUNT, badgeCount);
            mContext.SendBroadcast(intent);
        }

        internal override List<String> getSupportLaunchers()
        {
            List<string> supportedLaunchers = new List<string>();
            supportedLaunchers.Add("org.adw.launcher");
            supportedLaunchers.Add("org.adwfreak.launcher");
            return supportedLaunchers;
        }
    }
}

