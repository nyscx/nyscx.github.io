using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage
{
    HttpCookie authentication = new HttpCookie("loginDetails");
    protected void Page_Load(object sender, EventArgs e)
    {
        initchecker();
        
    }

    public void initchecker()
    {
        if (Request.Cookies["loginDetails"] != null)
        {
            if (Request.Cookies["loginDetails"]["username"] == null || Request.Cookies["loginDetails"]["login"] == null)
            {
                loginMode.Visible = true;
                logout.Visible = false;
                signup.Visible = true;
                food_Btn.Visible = false;
                healthstatus_Btn.Visible = false;
            }
            else
            {
                food_Btn.Visible = true;
                healthstatus_Btn.Visible = true;
                loginMode.Visible = false;
                logout.Visible = true;
                signup.Visible = false;
                pass.Text = "Welcome, " + Request.Cookies["loginDetails"]["username"] + "\t";

            }
        }
    }

    protected void login_Click(object sender, EventArgs e)
    {
        DataController v = new DataController();
        if (v.validate(username.Text, passwd.Text))
        {
            pass.Text = "Welcome, " + username.Text + "\t";
            authentication["username"] = username.Text;
            authentication["login"] = "1";
            authentication.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(authentication);
            loginMode.Visible = false;
            logout.Visible = true;
            signup.Visible = false;
            food_Btn.Visible = true;
            healthstatus_Btn.Visible = true;
            redirect();
        }
        else
        {
            displayError();
            //pass.Text = "Invalid Username/Password! " + v.Encrypt(passwd.Text, false);
        }
        v = null;

    }

    protected void logout_Click(object sender, EventArgs e)
    {
        HttpCookie authentication = new HttpCookie("loginDetails");
        authentication.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(authentication);
        Response.Redirect("home.aspx");
        food_Btn.Visible = false;
        healthstatus_Btn.Visible = false;
    }

    private void displayError()
    {
        pass.Text = "Invalid Username/Password! ";
    }

    private void redirect()
    {
        Response.Redirect("home.aspx?type=chas");
    }

    protected void loadPoly_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx?type=poly");

    }

    protected void chas_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx?type=chas");

    }

    protected void dengue_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx?type=dengue");

    }

    protected void food_Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("food.aspx");
    }

    protected void healthstatus_Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("HealthStatus.aspx");
    }
}
