using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Queens_Problem
{
    public partial class Form1 : Form
    {

        ButtonGenerator butt;
        Form mainFormHandler;
        public Form1()
        {
            InitializeComponent();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainFormHandler = Application.OpenForms[0];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            butt = new ButtonGenerator(flowLayoutPanel1);
            butt.generateButtons(Convert.ToInt32(input.Text));
            this.Size = new Size((Convert.ToInt32(input.Text) + 4) * 74, (Convert.ToInt32(input.Text) + 2) * 74); 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            butt.generateButtons(Convert.ToInt32(input.Text));
            this.Size = new Size((Convert.ToInt32(input.Text) + 4) * 74, (Convert.ToInt32(input.Text) + 2) * 74);
        }
    }
}
