using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class HuaweiHomeBadger : BaseBadge
    {
        static String INTENT_URI = "content://com.huawei.android.launcher.settings/badge/";
        static String INTENT_ACTION = "change_badge";
        static String INTENT_EXTRA_BADGE_COUNT = "badgenumber";
        static String INTENT_EXTRA_PACKAGENAME = "package";
        static String INTENT_EXTRA_ACTIVITY_NAME = "class";

        internal HuaweiHomeBadger() { }

        internal HuaweiHomeBadger(Context context) : base(context)
        {

        }

        internal override List<string> GetSupportLaunchers()
            => new List<string> { "com.huawei.android.launcher" };

        internal override void SetCount(int badgeCount)
        {
            CurrentCount = badgeCount;
            Bundle bundle = new Bundle();
            bundle.PutInt(INTENT_EXTRA_BADGE_COUNT, badgeCount);
            bundle.PutString(INTENT_EXTRA_PACKAGENAME, GetContextPackageName());
            bundle.PutString(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
            mContext.ContentResolver.Call(global::Android.Net.Uri.Parse(INTENT_URI), INTENT_ACTION, null, bundle);
        }
    }
}