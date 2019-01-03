using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace ThreadTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(txtCount.Text);
            DateTime dtBegin = DateTime.Now;
            string url = txtUrl.Text;
            int current = 0;
            for (int i = 0; i < count; i++)
            {
                while (current > 2000)
                {
                    Thread.Sleep(5);
                }
                current++;
                new System.Threading.Thread(new ThreadStart(delegate ()
                {
                    HttpHelper hh = new HttpHelper();
                    hh.HttpGet(url + "&A=" + i, "application/x-www-form-urlencoded");
                    current--;
                })).Start();
            }
        }
    }
}