using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class NovaHomeBadger : BaseBadge
    {
        private static String CONTENT_URI = "content://com.teslacoilsw.notifier/unread_count";
        private static String COUNT = "count";
        private static String TAG = "tag";

        internal NovaHomeBadger(Context context) : base(context)
        {
        }

        internal override void SetCount(int badgeCount)
        {
            try
            {
                CurrentCount = badgeCount;
                ContentValues contentValues = new ContentValues();
                contentValues.Put(TAG, getContextPackageName() + "/" + getEntryActivityName());
                contentValues.Put(COUNT, badgeCount);
                mContext.ContentResolver.Insert(global::Android.Net.Uri.Parse(CONTENT_URI), contentValues);
            }
            catch (Exception ex)
            {

            }
        }

        internal override List<String> getSupportLaunchers()
        {
            List<string> supportedLaunchers = new List<string>();
            supportedLaunchers.Add("com.teslacoilsw.launcher");
            return supportedLaunchers;
        }
    }
}

