using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows;

public partial class posting : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\localDB7.mdf;Integrated Security=True;Connect Timeout=30");
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = cn;
        string str = string.Format("Hello {0}, Please write your comment below.", Request.QueryString["user"]);
        Label1.Text = str;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(comment.Text))
        {
            cn.Open();
            cmd.CommandText = "insert into posts (username,comment,date,time) values ('" + Request.QueryString["user"] + "','" + comment.Text + "','" + DateTime.Today.ToString("M/dd/yyyy") + "','" + DateTime.Now.ToString("hh:mm tt") + "')";
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label2.Visible = true;
            Label2.Text = "Please Enter Your Comment!";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = string.Format("Default.aspx?curuser=hello");
        Response.Redirect(str);
    }

   
}