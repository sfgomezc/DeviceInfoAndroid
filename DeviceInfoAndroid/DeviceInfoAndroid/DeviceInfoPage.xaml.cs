using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeviceInfoAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();

            // Device Model (SMG-950U, iPhone10,6)
            var device = DeviceInfo.Model;
            LblDModel.Text = string.Format("Model: {0}", device);

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;
            LblDManufacturer.Text = string.Format("Manufacturer: {0}", manufacturer);

            // Device Name (Motz's iPhone)
            var deviceName = DeviceInfo.Name;
            LblDName.Text = string.Format("Name: {0}", deviceName);

            // Operating System Version Number (7.0)
            var versionString = DeviceInfo.VersionString;
            LblDVersionString.Text = string.Format("VersionString: {0}", versionString);

            var version = DeviceInfo.Version;
            LblDVersion.Text = string.Format("Version: {0}", version);

            // Platform (Android)
            var platform = DeviceInfo.Platform;
            LblDPlatform.Text = string.Format("Platform: {0}", platform);

            // Idiom (Phone)
            var idiom = DeviceInfo.Idiom;
            LblDIdiom.Text = string.Format("Idiom: {0}", idiom);

            // Device Type (Physical)
            var deviceType = DeviceInfo.DeviceType;
            LblDDeviceType.Text = string.Format("DeviceType: {0}", deviceType);
        }
    }
}