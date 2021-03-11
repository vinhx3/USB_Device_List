using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // https://www.c-sharpcorner.com/article/create-simple-web-api-in-asp-net-mvc/
            ManagementObjectCollection collection;
            using (var finddevice = new ManagementObjectSearcher(@"Select * from Win32_USBHub"))
                collection = finddevice.Get();
            foreach(var device in collection)
            {
                checkedListBox1.Items.Add(device.GetPropertyValue("DeviceID"));
                checkedListBox1.Items.Add(device.GetPropertyValue("Description"));

                int number = 0;

                if (Convert.ToString(device.GetPropertyValue("DeviceID")) == "USB\\VID_20EF&PID_0410\\J0000033")
                {
                    number = 1;
                    label1.Text =Convert.ToString(number);
                }
                else
                {
                    number = 0;
                    label1.Text = Convert.ToString(number);
                }


            }
        }
    }
}
