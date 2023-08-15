using Android.App;
using Android.Content;
using DeviceInfoAndroid.Droid;
using System;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(ReadPhoneStateService))]
namespace DeviceInfoAndroid.Droid
{
    class ReadPhoneStateService : IReadPhoneState
    {
        Android.Telephony.TelephonyManager mTelephonyMgr;

        public string GetPhoneIMEI()
        {
            mTelephonyMgr = (Android.Telephony.TelephonyManager)Application.Context.GetSystemService(Context.TelephonyService);
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Format("IMEI: {0}", mTelephonyMgr.Imei));
            str.AppendLine(string.Format("DeviceId: {0}", mTelephonyMgr.DeviceId));
            str.AppendLine(string.Format("Line1Number: {0}", mTelephonyMgr.Line1Number));
            str.AppendLine(string.Format("NetworkOperatorName: {0}", mTelephonyMgr.NetworkOperatorName));
            str.AppendLine(string.Format("SimOperatorName: {0}", mTelephonyMgr.SimOperatorName));
            str.AppendLine(string.Format("SimSerialNumber: {0}", mTelephonyMgr.SimSerialNumber));
            str.AppendLine(string.Format("SubscriberId:{0}", mTelephonyMgr.SubscriberId));

            return str.ToString();
        }
    }
}