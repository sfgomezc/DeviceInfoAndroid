using DeviceInfoAndroid.Droid;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDevice))]
namespace DeviceInfoAndroid.Droid
{
    public class AndroidDevice : IAndroidDevice
    {
        string IAndroidDevice.GetIdentifier()
        {
            var context = Android.App.Application.Context;
            string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            return id;
        }
    }
}