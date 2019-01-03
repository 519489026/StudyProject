using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
namespace StudyProject.Redis
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            RedisHelper rh = new RedisHelper();
            try
            {
                rh.Insert(txtKey.Text, txtValue.Text, 600);
                txtResult.Text = "写入成功";
            }
            catch(Exception ex)
            {
                txtResult.Text = JsonConvert.SerializeObject(ex);
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            RedisHelper rh = new RedisHelper();
            try
            {
                object obj = rh.Get(txtKey.Text);
                if(obj==null)
                {
                    txtResult.Text = "未读取到数据";
                }
                else
                {
                    txtResult.Text ="读取成功："+ obj.ToString();
                }
            }
            catch(Exception ex)
            {
                txtResult.Text = JsonConvert.SerializeObject(ex);
            }

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            RedisHelper rh = new RedisHelper();
            try
            {
                rh.Remove(txtKey.Text);
                txtResult.Text = "移除成功";
            }
            catch (Exception ex)
            {

                txtResult.Text = JsonConvert.SerializeObject(ex);
            }
        }
    }
}