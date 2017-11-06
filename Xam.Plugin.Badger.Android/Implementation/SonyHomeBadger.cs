using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class SonyHomeBadger : BaseBadge
	{
		static String INTENT_ACTION = "com.sonyericsson.home.action.UPDATE_BADGE";
		static String INTENT_EXTRA_PACKAGE_NAME = "com.sonyericsson.home.intent.extra.badge.PACKAGE_NAME";
		static String INTENT_EXTRA_ACTIVITY_NAME = "com.sonyericsson.home.intent.extra.badge.ACTIVITY_NAME";
		static String INTENT_EXTRA_MESSAGE = "com.sonyericsson.home.intent.extra.badge.MESSAGE";
		static String INTENT_EXTRA_SHOW_MESSAGE = "com.sonyericsson.home.intent.extra.badge.SHOW_MESSAGE";

        internal SonyHomeBadger() { }
        internal SonyHomeBadger(Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_ACTION);
			intent.PutExtra(INTENT_EXTRA_PACKAGE_NAME, GetContextPackageName());
			intent.PutExtra(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
			intent.PutExtra(INTENT_EXTRA_MESSAGE, badgeCount.ToString());
			intent.PutExtra(INTENT_EXTRA_SHOW_MESSAGE, badgeCount > 0);
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  GetSupportLaunchers() {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.sonyericsson.home");
			return supportedLaunchers;
		}
	}
}