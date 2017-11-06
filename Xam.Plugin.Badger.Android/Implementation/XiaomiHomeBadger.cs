using System;
using System.Collections.Generic;
using Android.Content;

namespace Xam.Plugin.Badger.Android.Implementation
{
    internal class XiaomiHomeBadger : BaseBadge
    {
        static String INTENT_ACTION = "android.intent.action.APPLICATION_MESSAGE_UPDATE";
        static String EXTRA_UPDATE_APP_COMPONENT_NAME = "android.intent.extra.update_application_component_name";
        static String EXTRA_UPDATE_APP_MSG_TEXT = "android.intent.extra.update_application_message_text";

        internal XiaomiHomeBadger(Context context) : base(context)
        {
        }

        internal override void SetCount(int badgeCount)
        {
            try
            {
                CurrentCount = badgeCount;
                Java.Lang.Class miuiNotificationClass = Java.Lang.Class.ForName("android.app.MiuiNotification");
                Java.Lang.Object miuiNotification = miuiNotificationClass.NewInstance();
                Java.Lang.Reflect.Field field = miuiNotification.Class.GetDeclaredField("messageCount");
                field.Accessible = true;
                field.Set(miuiNotification, badgeCount == 0 ? "" : badgeCount.ToString());
            }
            catch (Exception e)
            {
                Intent localIntent = new Intent(
                    INTENT_ACTION);
                localIntent.PutExtra(EXTRA_UPDATE_APP_COMPONENT_NAME, GetContextPackageName() + "/" + GetEntryActivityName());
                localIntent.PutExtra(EXTRA_UPDATE_APP_MSG_TEXT, badgeCount == 0 ? "" : badgeCount.ToString());
                mContext.SendBroadcast(localIntent);
            }
        }

        internal override List<String> GetSupportLaunchers()
        {
            List<string> supportedLaunchers = new List<string>();
            supportedLaunchers.Add("com.miui.miuilite");
            supportedLaunchers.Add("com.miui.home");
            supportedLaunchers.Add("com.miui.miuihome");
            supportedLaunchers.Add("com.miui.miuihome2");
            supportedLaunchers.Add("com.miui.mihome");
            supportedLaunchers.Add("com.miui.mihome2");
            return supportedLaunchers;
        }
    }
}
