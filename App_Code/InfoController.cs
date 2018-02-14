using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataSetTableAdapters;

/// <summary>
/// Summary description for InfoController
/// </summary>
public class InfoController
{
    private UserDBTableAdapter u = new UserDBTableAdapter();
    private HealthProblemTableAdapter h = new HealthProblemTableAdapter();
    private NutrientsDBTableAdapter n = new NutrientsDBTableAdapter();

    public InfoController()
    {   
    }

    public DataTable getInfo(String username)
    {
        return u.GetValidationDetails(username);
    }

    public DataTable viewUserHealthStatus(String username)
    {
        return u.GetFoodIntakeByUsername(username);
    }

    public DataTable viewUserDietInfo(String username)
    {
        return u.GetFoodIntakeByUsername(username);
    }

    public void updateUserFoodInfo(string food, string username)
    {
        u.UpdateFoodIntakeByUsername(food, username);
    }

    public DataTable getNutrients(String username)
    {
        return n.GetAllData();
    }

    public DataTable getHealthStatus(string username)
    {
        DataTable ret = new DataTable();
        DataTable dt = u.GetValidationDetails(username);
        if (dt.Rows.Count > 0)
        {
            string search = "";
            int years = DateTime.Now.Year - Convert.ToDateTime(dt.Rows[0]["Birthdate"].ToString()).Year;
            string gender = dt.Rows[0]["Gender"].ToString();
            gender = gender.Replace(" ", "");
            if (years < 13)
            {
                search += "AAA_12_";
            }
            else if (years < 30)
            {
                search += "AAA_30_";
            }
            else
            {
                search += "AAA_60_";
            }
            if (gender == "Male")
            {
                search += "M";
            }
            else
            {
                search += "F";
            }
            ret = n.GetFoodInfoByName(search);
        }
        if (dt.Rows[0]["HealthProblems"].ToString() != "" || dt.Rows[0]["HealthProblems"].ToString() != null)
        {
            string[] x = dt.Rows[0]["HealthProblems"].ToString().Split(',');
            foreach (string z in x)
            {
                DataTable a = n.GetFoodInfoByName(z);
                if (a.Rows.Count > 0)
                {
                    for (int i = 2; i < ret.Columns.Count; i++)
                    {
                        ret.Rows[0][i] = (Convert.ToDouble(ret.Rows[0][i].ToString()) * Convert.ToDouble(a.Rows[0][i].ToString()));
                        ret.AcceptChanges();
                    }
                }
            }
        }
        return ret;
    }
}