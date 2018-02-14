using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataSetTableAdapters;

public partial class HealthStatus : System.Web.UI.Page
{
    HealthProblemTableAdapter h = new HealthProblemTableAdapter();
    UserDBTableAdapter u = new UserDBTableAdapter();
    InfoController inf = new InfoController();
    DataTable userHealthProblem = new DataTable();
    FoodItem fi = new FoodItem();
    DataTable userFoodIntake = new DataTable();
    static string username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userFoodIntake.Columns.Add("Food");
        userFoodIntake.Columns.Add("Qty");
        userFoodIntake.AcceptChanges();
        userHealthProblem.Columns.Add("HealthProblem");
        if (Request.Cookies["loginDetails"]["username"] != null)
            username = Request.Cookies["loginDetails"]["username"];
        else
            Response.Redirect("Home.aspx?type=chas");
        userHealthProblem.AcceptChanges();
        loadHealthProblems();
        loadUserProblems();
        submit.Enabled = true;
        healthProb.Enabled = true;
        if (userHealthProblem.Rows.Count == healthProb.Items.Count - 1)
        {
            submit.Enabled = false;
            healthProb.Enabled = false;
        }
        


    }

    private void loadUserProblems()
    {
        String[] hp = inf.viewUserDietInfo(username).Rows[0]["HealthProblems"].ToString().Split(',');
        msg.Text = "";
        msg.Visible = false;
        gridv.Visible = true;
        if (hp != null && hp[0] != "")
        {
            for (int i = 0; i < hp.Length; i++)
            {
                DataRow dr = userHealthProblem.NewRow();
                hp[i] = hp[i].Replace("AAA_", "");
                dr[0] = hp[i];
                userHealthProblem.Rows.Add(dr);
                userHealthProblem.AcceptChanges();

            }
            gridv.DataSource = userHealthProblem;
            gridv.DataBind();
        }
        else
        {
            msg.Text = "You do not have any health problems";
            msg.Visible = true;
            gridv.Visible = false;

        }

        nutrients.DataSource = inf.getHealthStatus(username);
        nutrients.DataBind();

        String[] f = inf.viewUserDietInfo(username).Rows[0]["foodIntake"].ToString().Split('-');
        for(int i = 0; i < f.Length-1; i++)
        {
            int j = 0;
            bool non = false;
            for(j = 0; j < userFoodIntake.Rows.Count; j++)
            {
                if(f[i] == userFoodIntake.Rows[j]["Food"].ToString())
                {
                    non = true;
                    break;
                }
            }
            if (!non)
            {
                DataRow dr = userFoodIntake.NewRow();
                dr["Food"] = f[i];
                dr["Qty"] = 1;
                userFoodIntake.Rows.Add(dr);
                userFoodIntake.AcceptChanges();
            }
            else
            {
                userFoodIntake.Rows[j]["Qty"] = Convert.ToInt16(userFoodIntake.Rows[j]["Qty"].ToString()) + 1;
                userFoodIntake.AcceptChanges();
            }
        }

        foodintake.DataSource = userFoodIntake;
        foodintake.DataBind();

    }

    private void loadHealthProblems()
    {
        DataTable dt = h.GetAllHealthProblem();
        dt.AcceptChanges();
        if (!Page.IsPostBack)
        {
            healthProb.DataSource = dt;
            healthProb.DataValueField = "HealthProblem";
            healthProb.DataTextField = "HealthProblem";
            healthProb.DataBind();
            healthProb.Items.Insert(0, new ListItem("==== SELECT ONE ====", "0"));
        }

    }

    protected void removeProblem(object sender, EventArgs e)
    {
        Button b = sender as Button;
        GridViewRow gvr = (GridViewRow)b.NamingContainer;
        userHealthProblem.Rows.RemoveAt(gvr.RowIndex);
        userHealthProblem.AcceptChanges();
        gridv.DataSource = userHealthProblem;
        gridv.DataBind();

        string x = "";
        for(int i = 0; i < userHealthProblem.Rows.Count; i++)
        {
            string y = "AAA_" + userHealthProblem.Rows[i]["HealthProblem"];
            x += y+ ",";
            int j = i + 1;
            if (j == userHealthProblem.Rows.Count)
                x = x.Remove(x.Length - 1, 1);
        }
        u.UpdateHealthProblem(x, username);
        Response.Redirect("HealthStatus.aspx");
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if(healthProb.SelectedValue != "0")
        {
            for(int i =0; i < userHealthProblem.Rows.Count; i++)
            {
                if(healthProb.SelectedValue == userHealthProblem.Rows[i]["HealthProblem"].ToString())
                {
                    return;
                }
            }
            
            DataRow dr = userHealthProblem.NewRow();
            dr[0] = healthProb.SelectedValue;
            userHealthProblem.Rows.Add(dr);
            userHealthProblem.AcceptChanges();
            string x = "";
            for (int i = 0; i < userHealthProblem.Rows.Count; i++)
            {
                string y = "AAA_" + userHealthProblem.Rows[i]["HealthProblem"];
                x += y + ",";
                int j = i + 1;
                if (j == userHealthProblem.Rows.Count)
                    x = x.Remove(x.Length - 1, 1);
            }
            u.UpdateHealthProblem(x, username);
            
            Response.Redirect("HealthStatus.aspx");

        }
    }

    protected void gridv_RowCommand(object sender, GridViewCommandEventArgs e) {

        if(e.CommandName == "Removal")
        {
            Button b = sender as Button;
            String x = e.CommandArgument.ToString();
        }
    }
}