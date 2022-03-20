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
using System.Net;
using System.Net.NetworkInformation;

namespace cpuramss
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string processorInfo = null;
            string processorSerial = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_Processor");
            ManagementObjectCollection mObject = searcher.Get();

            foreach (ManagementObject obj in mObject)
            {
                processorSerial = obj["name"].ToString();
            }
            processorInfo = processorSerial;
            label2.Text = processorInfo;

            string osSerial = null;
            string osVersionInfo = null;
            string OSinfo = null;

            ManagementObjectSearcher osInfo = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");

            foreach (ManagementObject osInfoObj in osInfo.Get())
            {
                osSerial = (string)osInfoObj["Caption"];
                osVersionInfo = (string)osInfoObj["Version"];
                OSinfo = osSerial + " - " + osVersionInfo;
            }
            label4.Text = OSinfo;


            string videoControllerInfo = null;
            string name = null;
            string ram = null;
            string horizontalResolution = null;
            string verticalResolution = null;
            

            ManagementObjectSearcher vidSearcher = new ManagementObjectSearcher("Select * from Win32_VideoController Where availability='3'");

            foreach (ManagementObject tttttt in vidSearcher.Get())
            {
                name = tttttt["name"].ToString();
                ram = (Convert.ToDouble(tttttt["AdapterRam"]) / 1073741824).ToString();
                
                horizontalResolution = tttttt["CurrentHorizontalResolution"].ToString();
                verticalResolution = tttttt["CurrentVerticalResolution"].ToString();
            }
            videoControllerInfo = name + "\r\n Ram Miktarı : " + ram + " GB \r\n Çözünürlük :" + horizontalResolution + " x " + verticalResolution;
            if(name == null)
            { label6.Text = "!!!GPU OKUNAMADI!!!"+videoControllerInfo; }
            else
            { label6.Text = videoControllerInfo; }
            


            string ramSizeInfo = null;
            ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            foreach (ManagementObject rrrrr in ramSearcher.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(rrrrr["TotalPhysicalMemory"]));
                double ramgb = Ram_Bytes / 1073741824;
                double ramSize = Math.Ceiling(ramgb);
                ramSizeInfo = ramSize.ToString() + " GB";
            }
            label8.Text = ramSizeInfo;

        }
    }
}
