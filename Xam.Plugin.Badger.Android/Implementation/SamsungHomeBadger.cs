using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class SamsungHomeBadger : BaseBadge
    {
        static String INTENT_ACTION = "content://com.sec.badge/apps";
        static String INTENT_EXTRA_BADGE_COUNT = "badgecount";
        static String INTENT_EXTRA_PACKAGENAME = "package";
        static String INTENT_EXTRA_ACTIVITY_NAME = "class";

        internal SamsungHomeBadger(Context context) : base(context)
        {
        }

        internal override void SetCount(int badgeCount)
        {
            try
            {
                CurrentCount = badgeCount;
                ContentResolver localContentResolver = mContext.ContentResolver;
                global::Android.Net.Uri localUri = global::Android.Net.Uri.Parse(INTENT_ACTION);
                ContentValues localContentValues = new ContentValues();
                localContentValues.Put(INTENT_EXTRA_PACKAGENAME, GetContextPackageName());
                localContentValues.Put(INTENT_EXTRA_ACTIVITY_NAME, GetEntryActivityName());
                localContentValues.Put(INTENT_EXTRA_BADGE_COUNT, badgeCount);
                String str = "package=? AND class=?";
                String[] arrayOfString = new String[2];
                arrayOfString[0] = GetContextPackageName();
                arrayOfString[1] = GetEntryActivityName();

                int update = localContentResolver.Update(localUri, localContentValues, str, arrayOfString);

                if (update == 0)
                {
                    localContentResolver.Insert(localUri, localContentValues);
                }
            }
            catch (Exception localException)
            {
                global::Android.Util.Log.Error("CHECK", "Samsung : " + localException.Message);
            }
        }


        internal override List<String> GetSupportLaunchers()
        {
            List<string> supportedLaunchers = new List<string>();
            supportedLaunchers.Add("com.sec.android.app.launcher");
            supportedLaunchers.Add("com.sec.android.app.twlauncher");
            return supportedLaunchers;
        }
    }
}

