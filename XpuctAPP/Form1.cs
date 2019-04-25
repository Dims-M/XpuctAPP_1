using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XpuctAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

          Process process =  Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c time /t",
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden
                

            });
            label1.Text = process.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
