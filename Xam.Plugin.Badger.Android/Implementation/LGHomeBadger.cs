﻿using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class LGHomeBadger : BaseBadge
	{
		private static String INTENT_ACTION = "android.intent.action.BADGE_COUNT_UPDATE";
		private static String INTENT_EXTRA_BADGE_COUNT = "badge_count";
		private static String INTENT_EXTRA_PACKAGENAME = "badge_count_package_name";
		private static String INTENT_EXTRA_ACTIVITY_NAME = "badge_count_class_name";

        internal LGHomeBadger (Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
			Intent intent = new Intent(INTENT_ACTION);
			intent.PutExtra(INTENT_EXTRA_BADGE_COUNT, badgeCount);
			intent.PutExtra(INTENT_EXTRA_PACKAGENAME, getContextPackageName());
			intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, getEntryActivityName());
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  getSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.lge.launcher");
			supportedLaunchers.Add ("com.lge.launcher2");
			return supportedLaunchers;
		}
	}
}
