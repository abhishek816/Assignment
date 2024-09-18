using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Assignment
{
    public partial class _new : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-C64DN0LQ\SQLEXPRESS01;database=aspintro;Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select id,Name from form";
                SqlDataAdapter da = new SqlDataAdapter(s, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();

            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = DropDownList1.SelectedItem.Text;
            Label2.Text = DropDownList1.SelectedItem.Value;
            string str1="select * from form where id="+DropDownList1.SelectedItem.Value+"";
            SqlDataAdapter da = new SqlDataAdapter(str1, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select * from form";
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = "select Name,Age,Address,Photo from form";
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        
    }
}