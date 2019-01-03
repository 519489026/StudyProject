using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
namespace StudyProject.Thread
{
    public partial class ThreadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(txtCount.Text);
            DateTime dtBegin = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                new System.Threading.Thread(new ThreadStart(delegate()
                {
                    int result = 0;
                    for (int j = 0; j < 10000; j++)
                    {
                        result += j;
                    }
                })).Start();
            }
            double d = (DateTime.Now - dtBegin).TotalMilliseconds;
            txtResult.Text = d.ToString();
        }
    }
}