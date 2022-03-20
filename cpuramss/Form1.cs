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


namespace cpuramss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.chart1.Series["CPUT"].Points.Clear();
            this.chart1.Series["CPUT"].Points.Clear();
            this.chart1.Series["CPUT"].Points.Clear();
            label3.Visible = true;
            label3.Visible = false;
            //Cputemp
            try
            {
                float cput = performanceCounter3.NextValue();
                double cputeyp = cput - 273.15;
                label2.Text = cputeyp.ToString("0.##") + " C";
                if (cputeyp > 50)
                {
                    label2.ForeColor = Color.Yellow;
                    pictureBox1.Visible = false;
                }
                else if (cputeyp > 70)
                {
                    label2.ForeColor = Color.Red;
                    pictureBox1.Visible = true;
                }
                else
                {
                    label2.ForeColor = Color.Green;
                    pictureBox1.Visible = false;
                }
                this.chart1.Series["CPUT"].Points.AddXY("TEMP", (Convert.ToDouble(cputeyp)));
            }
            catch (Exception)
            { 
                label2.Text = "NOT ACCESSİBLE";                           
            }
           


            //Cpu
            float cpu = performanceCounter1.NextValue();
            label6.Text = "%" + cpu.ToString("0.##");
            progressBar1.Value = Convert.ToInt16(cpu);

            //Ram
            float ram = performanceCounter2.NextValue();
            label7.Text = "%" + ram.ToString("0.##");
            progressBar2.Value = Convert.ToInt16(ram);

           


            if (cpu > 75)
            {
                progressBar1.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;

            }
            else if (cpu > 50)
            {
                progressBar1.ForeColor = Color.Yellow;
                label6.ForeColor = Color.Yellow;

            }
            else
            {
                progressBar1.ForeColor = Color.Green;
                label6.ForeColor = Color.Green;
            }
            if (ram > 75)
            {
                progressBar2.ForeColor = Color.Red;
                pictureBox2.Visible = true;
                label7.ForeColor = Color.Red;
            }
            else if (ram > 50)
            {
                progressBar2.ForeColor = Color.Yellow;
                pictureBox2.Visible = false;
                label7.ForeColor = Color.Yellow;
            }
            else
            {
                progressBar2.ForeColor = Color.Green;
                pictureBox2.Visible = false;
                label7.ForeColor = Color.Green;
            }

            
            this.chart1.Series["CPUT"].Points.AddXY("CPU", (Convert.ToDouble(cpu)));
            this.chart1.Series["CPUT"].Points.AddXY("RAM", (Convert.ToDouble(ram)));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                float cput = performanceCounter3.NextValue();
                double cputeyp = cput - 273.15;
                label2.Text = cputeyp.ToString("0.##") + " C";
            }
            catch(Exception)
            {
                MessageBox.Show("HATA KODU:x0001 \n\n ISI DİLİMİ BİLGİLERİ ALINAMADI! \n Windows Management Instrumentation Service’ini (WMI Servisi) etkinleştirmeyi deneyin.", "SysTemp v1.04", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Visible = false;
                label2.Visible = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
