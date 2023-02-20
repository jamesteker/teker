using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Smart_Care
{
    /// <summary> uwu
    /// Interaction logic for RegisterDevice.xaml
    /// </summary>
    public partial class RegisterDevice : Window
    {
        public RegisterDevice()
        {
            InitializeComponent();
        }

        private async void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            //mag kwa value
            string device_Id1 = deviceID.Text;
            string ipaddress1 = ipAddress.Text;//
            var url = "http://192.168.254.114:8080/smartcare/registerDevice.php";

            var client = new HttpClient();

            var data = new Dictionary<string, string>
{
                {"device_id", device_Id1},
                {"ipaddress", ipaddress1}
            };

            var httpResponseMessage = await client.PostAsync(url, new FormUrlEncodedContent(data));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            if(content.ToString() == "success")
            {
                MessageBox.Show("Device registered successfully");
            }

            else
            {
                MessageBox.Show("Failed to register device");
            }
        }

 
    }
}
