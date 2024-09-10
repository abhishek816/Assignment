using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class changepass : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-C64DN0LQ\SQLEXPRESS01;database=aspintro;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "update form set Password='" + TextBox2.Text + "'where id=" + Session["uid"] + "";
            SqlCommand comm = new SqlCommand(sel, con);
            con.Open();
            int i = comm.ExecuteNonQuery();
            if (i == 1)
            {
                Label1.Text = "Password Changed!";
            }
        }
    }
}