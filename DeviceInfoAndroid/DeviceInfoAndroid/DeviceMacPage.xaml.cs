using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeviceInfoAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceMacPage : ContentPage
    {
        IAndroidDevice device = DependencyService.Get<IAndroidDevice>();

        public DeviceMacPage()
        {
            InitializeComponent();

            LblDMac1.Text = string.Format("MAC: {0}", GetDeviceInfo1());
            LblDMac2.Text = string.Format("MAC: {0}", GetDeviceInfo2());
        }

        private string GetDeviceInfo1()
        {
            string mac = string.Empty;
            string ip = string.Empty;

            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    var address = netInterface.GetPhysicalAddress();
                    mac = BitConverter.ToString(address.GetAddressBytes());

                    IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
                    if (addresses != null && addresses[0] != null)
                    {
                        ip = addresses[0].ToString();
                        break;
                    }
                }
            }

            return mac + (ip.Equals("") ? "" : " / "+ip);
        }

        private string GetDeviceInfo2()
        {
            var ni = NetworkInterface.GetAllNetworkInterfaces()
                .OrderBy(intf => intf.NetworkInterfaceType)
                .FirstOrDefault(intf => intf.OperationalStatus == OperationalStatus.Up
                    && (intf.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                    || intf.NetworkInterfaceType == NetworkInterfaceType.Ethernet));

            if (ni != null)
            {
                var hw = ni.GetPhysicalAddress();
                return string.Join(":", (from ma in hw.GetAddressBytes() select ma.ToString("x2")).ToArray());
            }

            return "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                LblDMac3.Text = await GetDeviceInfo3();
            }
            catch (Exception ex)
            {
                LblDMac3.Text = "Error: " + ex.Message;
            }
        }

        private async Task<string> GetDeviceInfo3()
        {
            PermissionStatus res = await CheckAndRequestPhonePermission();

            if (res == PermissionStatus.Granted)
            {
                var IMEI = DependencyService.Get<IReadPhoneState>().GetPhoneIMEI();
                return IMEI;
            }

            return "";
        }

        public async Task<PermissionStatus> CheckAndRequestPhonePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Phone>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Phone>();
            }

            return status;
        }
    }
}