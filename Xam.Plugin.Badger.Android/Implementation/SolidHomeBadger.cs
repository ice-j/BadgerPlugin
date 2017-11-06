using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class SolidHomeBadger : BaseBadge
	{
		private static String INTENT_UPDATE_COUNTER = "com.majeur.launcher.intent.action.UPDATE_BADGE";
		private static String PACKAGENAME = "com.majeur.launcher.intent.extra.BADGE_PACKAGE";
		private static String COUNT = "com.majeur.launcher.intent.extra.BADGE_COUNT";
		private static String CLASS = "com.majeur.launcher.intent.extra.BADGE_CLASS";

        internal SolidHomeBadger (Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_UPDATE_COUNTER);
			intent.PutExtra(PACKAGENAME, getContextPackageName());
			intent.PutExtra(COUNT, badgeCount);
			intent.PutExtra(CLASS, getEntryActivityName());
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  getSupportLaunchers() {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.majeur.launcher");
			return supportedLaunchers;
		}
	}
}

