using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class ApexHomeBadger : BaseBadge
	{
		private static String INTENT_UPDATE_COUNTER = "com.anddoes.launcher.COUNTER_CHANGED";
		private static String PACKAGENAME = "package";
		private static String COUNT = "count";
		private static String CLASS = "class";

        internal ApexHomeBadger (Context context) : base(context)
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

        internal override List<String>  getSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.anddoes.launcher");
			return supportedLaunchers;
		}
    }
}