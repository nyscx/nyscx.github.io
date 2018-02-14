using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSetTableAdapters;

public partial class Signup : System.Web.UI.Page
{
    DataController v = new DataController();
    UserDBTableAdapter u = new UserDBTableAdapter();
    EmailServer em = new EmailServer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected bool validate()
    {
        if (!v.checkUserExists(username.Text) && username.Text.Length >= 3)
        {
            if (password.Text == vPassword.Text && !(password.Text == "" || password.Text == null) && password.Text.Length >= 7)
            {
                if (poscod.Text.Length == 6)
                {
                    DateTime t;
                    if (DateTime.TryParse(bday.Text, out t))
                    {
                        if (t.Year > 1900 && DateTime.Compare(DateTime.Today, t) > 0)
                        {
                            return true;
                        }
                        else
                        {
                            errorMsg.Text = "Please enter a valid date! (dd/mm/yyyy, date before today)";
                        }
                    }
                    else
                    {
                        errorMsg.Text = "Please enter a valid date (dd/mm/yyyy, date after 1/1/1900)";
                    }
                }
                else
                {
                    errorMsg.Text = "Please enter a 6-digit postal code.";
                }
            }
            else
            {
                errorMsg.Text = "Please enter a valid password! (minimum 8 characters)";
            }
        }
        else
        {
            errorMsg.Text = "Please choose another Username! (taken or length less than 3.";
        }
        return false;
    }

    protected void submitItem_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            string g = gender.SelectedValue;
            if (g == "")
            {
                g = "Male";
            }
            if (v.createUser(username.Text, password.Text, "", g, poscod.Text, bday.Text, email.Text))
            {
                em.sendMail(email.Text, username.Text);
                shadow.Visible = true;
            }
            else
            {
                errorMsg.Text = "Error in creating";
            }
        }
    }
}