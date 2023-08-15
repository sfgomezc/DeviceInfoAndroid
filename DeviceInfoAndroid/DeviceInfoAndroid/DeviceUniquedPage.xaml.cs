using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeviceInfoAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceUniquedPage : ContentPage
    {
        IAndroidDevice device = DependencyService.Get<IAndroidDevice>();

        public DeviceUniquedPage()
        {
            InitializeComponent();

            string deviceIdentifier = device.GetIdentifier();
            LblDIdentifier.Text = string.Format("Identifier: {0}", deviceIdentifier);
        }
    }
}