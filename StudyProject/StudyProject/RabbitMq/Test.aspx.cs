using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyProject.RabbitMq
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int count=Convert.ToInt32(txtCount.Text);
            DateTime dtBegin=DateTime.Now;
            //for(int i=0;i<count;i++)
            //{
                RabbitMqHelper.Add("", "test", "0", false);
            //}
            double total=(DateTime.Now-dtBegin).TotalMilliseconds;
            txtResult.Text="操作成功，共计用时"+total+"毫秒";

        
        }

        protected void btnConsume_Click(object sender, EventArgs e)
        {

        }

        protected void btnRead_Click(object sender, EventArgs e)
        {

        }
    }
}