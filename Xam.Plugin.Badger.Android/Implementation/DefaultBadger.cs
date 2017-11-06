using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class DefaultBadger : BaseBadge
	{
		static String INTENT_ACTION = "android.intent.action.BADGE_COUNT_UPDATE";
		static String INTENT_EXTRA_BADGE_COUNT = "badge_count";
		static String INTENT_EXTRA_BADGE_COUNT2 = "badgecount";
        static String INTENT_EXTRA_PACKAGENAME = "badge_count_package_name";
		static String INTENT_EXTRA_ACTIVITY_NAME = "badge_count_class_name";

        internal DefaultBadger() { }

        internal DefaultBadger (Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_ACTION);
			intent.PutExtra(INTENT_EXTRA_BADGE_COUNT, badgeCount);
			intent.PutExtra(INTENT_EXTRA_BADGE_COUNT2, badgeCount);
			intent.PutExtra(INTENT_EXTRA_PACKAGENAME, GetContextPackageName());
			intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  GetSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			return supportedLaunchers;
		}
	}
}
