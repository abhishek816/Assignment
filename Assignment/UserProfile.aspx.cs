using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class UserProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-C64DN0LQ\SQLEXPRESS01;database=aspintro;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select Name,Age,Address,Phone,Photo from form where id=" + Session["uid"]+"";
                SqlCommand comm = new SqlCommand(sel,con);
                con.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    TextBox4.Text = dr["Phone"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();
                }
                con.Close();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel1 = "update form set Age=" + TextBox2.Text + ",Address='" + TextBox3.Text + "'where id=" + Session["uid"] + "";
            SqlCommand comm1 = new SqlCommand(sel1, con);
            con.Open();
            int i = comm1.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                Label1.Text = "Updated!";
            }
        }
    }
}