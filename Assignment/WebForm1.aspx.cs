using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-C64DN0LQ\SQLEXPRESS01;database=aspintro;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Label14.Text = TextBox1.Text;
            Label16.Text = TextBox2.Text;
            Label18.Text = TextBox3.Text;
            Label20.Text = TextBox4.Text;
            Label25.Text = TextBox5.Text;
            Label24.Text = RadioButtonList1.SelectedItem.Text;
            Label27.Text = DropDownList1.SelectedItem.Text;
            string s = "";
            //for(int i = 0; i < CheckBoxList1.Items.Count; i++)
            //{
            //    if (CheckBoxList1.Items[i].Selected)
            //    {
            //        s = s + CheckBoxList1.Items[i].Text + ",";
            //    }
            //}
            Label29.Text = s;
            string p = "~/SavedImages/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            Image1.ImageUrl = p;
            Label32.Text = TextBox6.Text;
            Label35.Text = TextBox7.Text;
            Label37.Text = TextBox8.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string p = "~/SavedImages/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string sel = "";
            for (int i= 0;i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    sel += CheckBoxList1.Items[i].Text;
                }
            }
            string str ="insert into form values('"+TextBox1.Text+"',"+TextBox2.Text+",'"+TextBox3.Text+"',"+TextBox4.Text+",'"+TextBox5.Text+"','"+RadioButtonList1.SelectedItem.Text+"','"+DropDownList1.SelectedItem.Text+"','"+sel+"','"+p+"','"+TextBox6.Text+"','"+TextBox7.Text+"')";
            SqlCommand comm = new SqlCommand(str, con);
            con.Open();
            int j = comm.ExecuteNonQuery();
            con.Close();
            if (j != 0)
            {
                Label38.Text = "Inserted";
            }
            else
            {
                Label38.Text = "Not Inserted";
            }
            
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

        }
    }
}