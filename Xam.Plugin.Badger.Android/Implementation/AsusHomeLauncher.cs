using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Droid.Implementation
{
    internal class AsusHomeLauncher : BaseBadge
	{
		static String INTENT_ACTION = "android.intent.action.BADGE_COUNT_UPDATE";
		static String INTENT_EXTRA_BADGE_COUNT = "badge_count";
		static String INTENT_EXTRA_PACKAGENAME = "badge_count_package_name";
		static String INTENT_EXTRA_ACTIVITY_NAME = "badge_count_class_name";

        internal AsusHomeLauncher() { }
        internal AsusHomeLauncher(Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_ACTION);
			intent.PutExtra(INTENT_EXTRA_BADGE_COUNT, badgeCount);
			intent.PutExtra(INTENT_EXTRA_PACKAGENAME, GetContextPackageName());
			intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
			intent.PutExtra("badge_vip_count", 0);
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  GetSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.asus.launcher");
			return supportedLaunchers;
		}
	}
}