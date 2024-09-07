using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class login_page : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-C64DN0LQ\SQLEXPRESS01;database=aspintro;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(id) from form where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            SqlCommand comm = new SqlCommand(str, con);
            con.Open();
            string cid = comm.ExecuteScalar().ToString();
            con.Close();
            if (cid == "1")
            {
                string str2 = "select id from form where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                SqlCommand comm1 = new SqlCommand(str, con);
                con.Open();
                string id = comm1.ExecuteScalar().ToString();
                con.Close();
                Session["uid"] = id;
                Response.Redirect("UserProfile.aspx");
            }
            else
            {
                Label3.Text = "Invalid username and password!";
            }
        }
    }
}