using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class GridEditDelete : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-C64DN0LQ\SQLEXPRESS01;database=aspintro;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_grid();
            }
        }
        public void bind_grid()
        {
            string str = "select * from form";
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label1.Text = rw.Cells[2].Text;
            Label2.Text = rw.Cells[3].Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del="delete from form where id="+getid+"";
            SqlCommand com = new SqlCommand(del, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            bind_grid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind_grid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind_grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtage = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtaddr = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            string strup = "update form set Age=" + txtage.Text + " ,Address='" + txtaddr.Text + "'where id=" + getid + "";
            SqlCommand comm = new SqlCommand(strup,con);
            con.Open();
            comm.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            bind_grid();
        }
    }
}