using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Droid.Implementation
{
    internal class NewHtcHomeBadger : BaseBadge
	{
		static String INTENT_UPDATE_SHORTCUT = "com.htc.launcher.action.UPDATE_SHORTCUT";
		static String INTENT_SET_NOTIFICATION = "com.htc.launcher.action.SET_NOTIFICATION";
		static String PACKAGENAME = "packagename";
		static String COUNT = "count";
		static String EXTRA_COMPONENT = "com.htc.launcher.extra.COMPONENT";
		static String EXTRA_COUNT = "com.htc.launcher.extra.COUNT";

        internal NewHtcHomeBadger() { }
        internal NewHtcHomeBadger(Context context) : base(context)
		{
		}

        internal override void SetCount(int badgeCount)
		{
            CurrentCount = badgeCount;
			Intent intent1 = new Intent(INTENT_SET_NOTIFICATION);
			ComponentName localComponentName = new ComponentName(GetContextPackageName(), GetEntryActivityName());
			intent1.PutExtra(EXTRA_COMPONENT, localComponentName.FlattenToShortString());
			intent1.PutExtra(EXTRA_COUNT, badgeCount);
			mContext.SendBroadcast(intent1);

			Intent intent = new Intent(INTENT_UPDATE_SHORTCUT);
			intent.PutExtra(PACKAGENAME, GetContextPackageName());
			intent.PutExtra(COUNT, badgeCount);
			mContext.SendBroadcast(intent);
		}

        internal override List<String>  GetSupportLaunchers()
        {
			List<string> supportedLaunchers = new List<string> ();
			supportedLaunchers.Add ("com.htc.launcher");
			return supportedLaunchers;
		}
	}
}

