using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class SonyHomeBadger : BaseBadge
	{
		private static String INTENT_ACTION = "com.sonyericsson.home.action.UPDATE_BADGE";
		private static String INTENT_EXTRA_PACKAGE_NAME = "com.sonyericsson.home.intent.extra.badge.PACKAGE_NAME";
		private static String INTENT_EXTRA_ACTIVITY_NAME = "com.sonyericsson.home.intent.extra.badge.ACTIVITY_NAME";
		private static String INTENT_EXTRA_MESSAGE = "com.sonyericsson.home.intent.extra.badge.MESSAGE";
		private static String INTENT_EXTRA_SHOW_MESSAGE = "com.sonyericsson.home.intent.extra.badge.SHOW_MESSAGE";

        internal SonyHomeBadger (Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_ACTION);
			intent.PutExtra(INTENT_EXTRA_PACKAGE_NAME, getContextPackageName());
			intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, getEntryActivityName());
			intent.PutExtra(INTENT_EXTRA_MESSAGE, badgeCount.ToString());
			intent.PutExtra(INTENT_EXTRA_SHOW_MESSAGE, badgeCount > 0);
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  getSupportLaunchers() {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.sonyericsson.home");
			return supportedLaunchers;
		}
	}
}