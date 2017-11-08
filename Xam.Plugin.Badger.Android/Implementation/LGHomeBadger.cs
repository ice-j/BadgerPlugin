using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Droid.Implementation
{
    internal class LGHomeBadger : BaseBadge
	{
		static String INTENT_ACTION = "android.intent.action.BADGE_COUNT_UPDATE";
		static String INTENT_EXTRA_BADGE_COUNT = "badge_count";
		static String INTENT_EXTRA_PACKAGENAME = "badge_count_package_name";
		static String INTENT_EXTRA_ACTIVITY_NAME = "badge_count_class_name";

        internal LGHomeBadger() { }
        internal LGHomeBadger(Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_ACTION);
			intent.PutExtra(INTENT_EXTRA_BADGE_COUNT, badgeCount);
			intent.PutExtra(INTENT_EXTRA_PACKAGENAME, GetContextPackageName());
			intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  GetSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.lge.launcher");
			supportedLaunchers.Add ("com.lge.launcher2");
			return supportedLaunchers;
		}
	}
}
