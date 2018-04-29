using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\localDB7.mdf;Integrated Security=True;Connect Timeout=30");
    SqlCommand cmd = new SqlCommand();
    int i = 0;
    public static int flag = 0;
    public static string currentuser;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = flag.ToString();
        if (Label2.Text == "0")
        {
            Label1.Text = "Please Login First!";
        }
        else
        {
            Label1.Text = "Logged In!";
            Label3.Text = currentuser;
        }
        cmd.Connection = cn;
        DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);

        TableHeaderRow hr = new TableHeaderRow();

        TableHeaderCell h1 = new TableHeaderCell();
        TableHeaderCell h2 = new TableHeaderCell();
        TableHeaderCell h3 = new TableHeaderCell();

        hr.Cells.Add(h1);
        hr.Cells.Add(h2);
        hr.Cells.Add(h3);

        h1.BorderWidth = 1;
        h1.BorderColor = Color.Black;
        h1.Width = 10;
        h2.BorderWidth = 1;
        h2.BorderColor = Color.Black;
        h2.Width = 20;
        h3.BorderWidth = 1;
        h3.BorderColor = Color.Black;
        h3.Width = 20;

        h1.Text = "User";
        h2.Text = "Comment";
        h3.Text = "Date";

        Table1.Rows.Add(hr);

        foreach (DataRow dr in dv.Table.Rows)
        {
            TableRow r = new TableRow();

            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();

            r.Cells.Add(c1);
            r.Cells.Add(c2);
            r.Cells.Add(c3);

            c1.BorderWidth = 1;
            c1.BorderColor = Color.Black;
            c1.Width = 400;
            c2.BorderWidth = 1;
            c2.BorderColor = Color.Black;
            c2.Width = 800;
            c3.BorderWidth = 1;
            c3.BorderColor = Color.Black;
            c3.Width = 400;

            c1.Text = dr["username"].ToString();
            c2.Text = dr["comment"].ToString();
            string str = string.Format("{0}\t{1}", dr["time"].ToString(), dr["date"].ToString());
            c3.Text = str;

            Table1.Rows.Add(r);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = "select * from userdata where username = '" + username.Text + "' and password = '" + password.Text + "'";
        SqlDataAdapter sda = new SqlDataAdapter(query, cn);
        DataTable dtb = new DataTable();
        sda.Fill(dtb);
        if (flag == 0)
        {
            if (dtb.Rows.Count == 1)
            {
                Label1.Text = "Logged In!";
                password.Text = "";
                flag = 1;
                Label3.Text = username.Text;
                currentuser = username.Text;
                username.Text = "";
            }
            else
            {
                Label1.Text = "Please enter correct Username and Password!";
            }
        }
        else
        {
            Label1.Text = "You already Logged In!";
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(newun.Text) && !string.IsNullOrEmpty(newpw.Text))
        {
            cn.Open();
            cmd.CommandText = "insert into userdata (username,password) values ('" + newun.Text + "','" + newpw.Text + "')";
            cmd.ExecuteNonQuery();
            cn.Close();
            Label1.Text = "Account has been successfully created! Please login to post!";
            newun.Text = "";
            newpw.Text = "";
        }
        else
        {
            Label1.Text = "Please enter correct username and password!";
        }
      
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Label2.Text == "1")
        {
            string url = string.Format("posting.aspx?user={0}", Label3.Text);
            Response.Redirect(url);
        }
        else
        {
            Label1.Text = "Only logged in user could post!";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (flag == 1)
        {
            flag = 0;
            currentuser = "";
            Label1.Text = "Logged Out!";
        }
        else
        {
            Label1.Text = "You havn't Logged In!";
        }
    }
}