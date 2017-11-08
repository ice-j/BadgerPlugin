using System;
using System.Collections.Generic;
using Android.Content;
using Android.Database;

namespace Xam.Plugin.Badger.Droid.Implementation
{
    internal class SamsungHomeBadger : BaseBadge
    {
        static String INTENT_ACTION = "android.intent.action.BADGE_COUNT_UPDATE";
        static String INTENT_EXTRA_BADGE_COUNT = "badge_count";
        static String INTENT_EXTRA_PACKAGENAME = "badge_count_package_name";
        static String INTENT_EXTRA_ACTIVITY_NAME = "badge_count_class_name";

        internal SamsungHomeBadger() { }
        internal SamsungHomeBadger(Context context) : base(context)
        {
        }

        internal override void SetCount(int badgeCount)
        {
            try
            {
                CurrentCount = badgeCount;
                Intent intent = new Intent(INTENT_ACTION);
                intent.PutExtra(INTENT_EXTRA_BADGE_COUNT, badgeCount);
                intent.PutExtra(INTENT_EXTRA_PACKAGENAME, GetContextPackageName());
                intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
                mContext.SendBroadcast(intent);
            }
            catch (Exception localException)
            {
                global::Android.Util.Log.Error("CHECK", "Samsung : " + localException.Message);
            }
        }


        internal override List<String> GetSupportLaunchers()
        {
            List<string> supportedLaunchers = new List<string>();
            supportedLaunchers.Add("com.sec.android.app.launcher");
            supportedLaunchers.Add("com.sec.android.app.twlauncher");
            return supportedLaunchers;
        }
    }
}

