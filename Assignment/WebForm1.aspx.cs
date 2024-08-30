using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
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
            for(int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    s = s + CheckBoxList1.Items[i].Text + ",";
                }
            }
            Label29.Text = s;
            string p = "~/SavedImages/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            Image1.ImageUrl = p;
            Label32.Text = TextBox6.Text;
            Label35.Text = TextBox7.Text;
            Label37.Text = TextBox8.Text;
        }
    }
}