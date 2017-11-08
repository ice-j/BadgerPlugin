using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Droid.Implementation
{
    internal class ApexHomeBadger : BaseBadge
	{
		static String INTENT_UPDATE_COUNTER = "com.anddoes.launcher.COUNTER_CHANGED";
		static String PACKAGENAME = "package";
		static String COUNT = "count";
		static String CLASS = "class";

        internal ApexHomeBadger() { }
        internal ApexHomeBadger(Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent = new Intent(INTENT_UPDATE_COUNTER);
			intent.PutExtra(PACKAGENAME, GetContextPackageName());
			intent.PutExtra(COUNT, badgeCount);
			intent.PutExtra(CLASS, GetEntryActivityName());
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  GetSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.anddoes.launcher");
			return supportedLaunchers;
		}
    }
}