using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace cpuramss
{
    public partial class anasayfa : Form
    {

        public anasayfa()
        {
            InitializeComponent();
        }

        

        public void Formgetir(Form frm)
        {
            //orj
            panel1.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            //orj
        }

  
        
        private void button1_Click(object sender, EventArgs e)
        {

            this.Opacity = Properties.Settings.Default.opaklık;
            panel2.BackColor = Properties.Settings.Default.arkaplan;
            Form1 anlık = new Form1();
            Formgetir(anlık);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Opacity = Properties.Settings.Default.opaklık;
            panel2.BackColor = Properties.Settings.Default.arkaplan;
            Form2 anlık = new Form2();
            Formgetir(anlık);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Opacity = Properties.Settings.Default.opaklık;
            panel2.BackColor = Color.WhiteSmoke;
            Form3 anlık = new Form3();
            Formgetir(anlık);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.Opacity = Properties.Settings.Default.opaklık;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                button3.Text="SAYDAM";
                button3.BackColor = Color.Red;
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
            }
            else
            {
                this.Opacity = Properties.Settings.Default.oyunmodu;
                this.FormBorderStyle = FormBorderStyle.None;
                button3.Text = "OPAK";
                button3.BackColor = Color.Green;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
            }
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
                     
        }
        //orj
        public event EventHandler MinimizeEvent;
        protected virtual void OnMinimize(EventArgs e)
        {
            if (MinimizeEvent != null) MinimizeEvent(this, e);
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = true; 
            }
        }
        private const int WM_SYSCOMMAND = 0x0112,
            SC_MINIMIZE = 0xf020;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            { this.ShowInTaskbar = false; }
        }

        private void anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.konum = Location ;
            Properties.Settings.Default.Save();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam == (IntPtr)SC_MINIMIZE)
            {
                m.Result = (IntPtr)1;
                OnMinimize(new EventArgs());
                return;
            }
            base.WndProc(ref m);
        }
    }
}
