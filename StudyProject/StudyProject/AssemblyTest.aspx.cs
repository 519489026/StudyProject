using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
namespace StudyProject
{
    public partial class AssemblyTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Assembly.Load("Test").CreateInstance("StudyProject.Test", 3, "test");
        }
    }
    public class Test
    {

        public void SetV(int parmId,string parmName)
        {
            id = parmId;
            name = parmName;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}