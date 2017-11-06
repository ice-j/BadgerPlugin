using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class NewHtcHomeBadger : BaseBadge
	{
		public static String INTENT_UPDATE_SHORTCUT = "com.htc.launcher.action.UPDATE_SHORTCUT";
		public static String INTENT_SET_NOTIFICATION = "com.htc.launcher.action.SET_NOTIFICATION";
		public static String PACKAGENAME = "packagename";
		public static String COUNT = "count";
		public static String EXTRA_COMPONENT = "com.htc.launcher.extra.COMPONENT";
		public static String EXTRA_COUNT = "com.htc.launcher.extra.COUNT";

        internal NewHtcHomeBadger (Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
			Intent intent1 = new Intent(INTENT_SET_NOTIFICATION);
			ComponentName localComponentName = new ComponentName(getContextPackageName(), getEntryActivityName());
			intent1.PutExtra(EXTRA_COMPONENT, localComponentName.FlattenToShortString());
			intent1.PutExtra(EXTRA_COUNT, badgeCount);
			mContext.SendBroadcast(intent1);

			Intent intent = new Intent(INTENT_UPDATE_SHORTCUT);
			intent.PutExtra(PACKAGENAME, getContextPackageName());
			intent.PutExtra(COUNT, badgeCount);
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  getSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.htc.launcher");
			return supportedLaunchers;
		}
	}
}

