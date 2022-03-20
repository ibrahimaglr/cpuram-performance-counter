using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cpuramss
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
           Properties.Settings.Default.opaklık = (double)trackBar1.Value / 100;
            Properties.Settings.Default.Save();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          trackBar1.Value = Convert.ToInt32(Properties.Settings.Default.opaklık * 100);
            trackBar2.Value = Convert.ToInt32(Properties.Settings.Default.oyunmodu * 100);
        }
        
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.oyunmodu = (double)trackBar2.Value / 100;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Properties.Settings.Default.arkaplan = colorDialog1.Color;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("ibrahimaglar@hotmail.com", "Systemp v1.04", MessageBoxButtons.OK, MessageBoxIcon.Information); ; ;
        }
    }
}
