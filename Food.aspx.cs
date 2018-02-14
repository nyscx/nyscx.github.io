using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSetTableAdapters;

public partial class updateFood : System.Web.UI.Page
{

    private FoodItem f = new FoodItem();
    static List<FoodItem> foods = new List<FoodItem>();
    static List<FoodItem> existingFood = new List<FoodItem>();
    private DataController dc = new DataController();
    private static DataTable userFoodIntake = new DataTable();
    private static DataTable uFintake = new DataTable();
    private static DataTable userTable = new DataTable();
    private InfoController inf = new InfoController();
    static bool update = false;
    private static string username = "";
    private static string RDAExceed = "";
    static double tCal = 0, tSatFat = 0, tPolyFat = 0, tMonoFat = 0, tTransFat = 0, tSodium = 0, tPotassium = 0, tCholesterol = 0, tProtein = 0, tSugar = 0, tDFibre = 0, tVitA = 0, tVitC = 0, tCalcium = 0, tIron = 0, tTotalFat = 0, tCarbo;
    static double uCal = 0, uSatFat = 0, uPolyFat = 0, uMonoFat = 0, uTransFat = 0, uSodium = 0, uPotassium = 0, uCholesterol = 0, uProtein = 0, uSugar = 0, uDFibre = 0, uVitA = 0, uVitC = 0, uCalcium = 0, uIron = 0, uTotalFat = 0, uCarbo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginDetails"] != null)
        {
            if (Request.Cookies["loginDetails"]["login"] != null)
            {
                if (!userFoodIntake.Columns.Contains("Food"))
                {
                    userFoodIntake.Columns.Add("Food");
                }
                if (!userFoodIntake.Columns.Contains("Qty"))
                {
                    userFoodIntake.Columns.Add("Qty");
                }

                userFoodIntake.AcceptChanges();
                username = Request.Cookies["loginDetails"]["username"].ToString();
                uFintake = inf.viewUserDietInfo(username);
                userTable = inf.viewUserHealthStatus(username);
                whatIate.Text = "";
                viewDietInfo();
                displayFood(null, true);
                displayFood(null, false);

            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }
        else
        {
            Response.Redirect("home.aspx");
        }

        if (!Page.IsPostBack)
        {
            update = true;
            DataTable dt = f.getAllFoodName();
            chooseFood.DataSource = dt;
            chooseFood.DataValueField = "name";
            chooseFood.DataTextField = "name";
            chooseFood.DataBind();
            chooseFood.Items.Insert(0, new ListItem("----- SELECT FOOD ITEM -----", "0"));
            viewDietInfo();
            if (foods.Count != 0)
            {
                displayFood(null, false);
            }
            displayFood(null, true);
        }
    }

    protected void viewDietInfo()
    {
        existingFood.Clear();
        userFoodIntake.Rows.Clear();
        userFoodIntake.AcceptChanges();
        String[] ff = inf.viewUserDietInfo(username).Rows[0]["foodIntake"].ToString().Split('-');
        if (update)
        {
            for (int i = 0; i < ff.Length - 1; i++)
            {
                int j = 0;
                bool non = false;
                for (j = 0; j < userFoodIntake.Rows.Count; j++)
                {
                    if (ff[i] == userFoodIntake.Rows[j]["Food"].ToString())
                    {
                        non = true;
                        break;
                    }
                }
                if (!non)
                {
                    DataRow dr = userFoodIntake.NewRow();
                    dr["Food"] = ff[i];
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


        fromDB.Text = uFintake.Rows[0]["FoodIntake"].ToString();
        string[] exist = uFintake.Rows[0]["FoodIntake"].ToString().Split('-');
        foreach (string x in exist)
        {
            existingFood.Add(new FoodItem(x));
            clearFood.Enabled = true;
        }
        foreach (FoodItem f in foods)
        {
            whatIate.Text += f.Name + "-";

        }
        DataTable d = inf.getHealthStatus(username);
        uCal = Convert.ToDouble(d.Rows[0]["Calories"].ToString());
        uSatFat = Convert.ToDouble(d.Rows[0]["SaturatedFat"].ToString());
        uPolyFat = Convert.ToDouble(d.Rows[0]["PolyunsaturatedFat"].ToString());
        uMonoFat = Convert.ToDouble(d.Rows[0]["MonounsaturatedFat"].ToString());
        uSodium = Convert.ToDouble(d.Rows[0]["Sodium"].ToString());
        uIron = Convert.ToDouble(d.Rows[0]["Iron"].ToString());
        uTotalFat = Convert.ToDouble(d.Rows[0]["TotalFat"].ToString());
        uTransFat = Convert.ToDouble(d.Rows[0]["TransFat"].ToString());
        uCholesterol = Convert.ToDouble(d.Rows[0]["Cholesterol"].ToString());
        uCalcium = Convert.ToDouble(d.Rows[0]["Calcium"].ToString());
        uVitA = Convert.ToDouble(d.Rows[0]["VitA"].ToString());
        uVitC = Convert.ToDouble(d.Rows[0]["VitC"].ToString());
        uPotassium = Convert.ToDouble(d.Rows[0]["Potassium"].ToString());
        uDFibre = Convert.ToDouble(d.Rows[0]["DietaryFibre"].ToString());
        uSugar = Convert.ToDouble(d.Rows[0]["Sugar"].ToString());
        uCarbo = Convert.ToDouble(d.Rows[0]["Carbohydrate"].ToString());
        uProtein = Convert.ToDouble(d.Rows[0]["Protein"].ToString());
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string chosenFood = chooseFood.SelectedValue;
        selectedFood.Text = chosenFood;
        if (chosenFood != "0")
        {
            FoodItem f = new FoodItem(chosenFood);
            foods.Add(f);
            displayFood(f, false);
            whatIate.Text += f.Name + "-";
            saveFood.Enabled = true;
        }
    }

    protected void reset()
    {
        tCal = 0;
        tSatFat = 0;
        tPolyFat = 0;
        tMonoFat = 0;
        tSodium = 0;
        tIron = 0;
        tTotalFat = 0;
        tTransFat = 0;
        tCholesterol = 0;
        tCalcium = 0;
        tVitA = 0;
        tVitC = 0;
        tPotassium = 0;
        tDFibre = 0;
        tSugar = 0;
        tCarbo = 0;
        tProtein = 0;

    }

    public void checkRDA()
    {
        RDAExceed = "";
        bool popup = false;
        if (tCal > uCal)
        {
            totalCal.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Calories, ";
            popup = true;

        }
        if (tSatFat > uSatFat)
        {
            totalSatFat.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Saturated Fat, ";
            popup = true;

        }
        if (tPolyFat > uPolyFat)
        {
            TotalPolyFat.ForeColor = System.Drawing.Color.Red;
            popup = true;
            RDAExceed += "Polyunsaturated Fat, ";
        }
        if (tMonoFat > uMonoFat)
        {
            popup = true;
            TotalMonoFat.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Monounsaturated Fat, ";
        }
        if (tTransFat > uTransFat)
        {
            popup = true;
            TotalTransFat.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Trans Fat, ";
        }
        if (tSodium > uSodium)
        {
            popup = true;
            TotalSodium.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Sodium, ";
        }
        if (tSugar > uSugar)
        {
            popup = true;
            TotalSugar.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Sugar, ";
        }
        if (tTotalFat > uTotalFat)
        {
            popup = true;
            TotalFat.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Total Fat, ";
        }
        if (tCarbo > uCarbo)
        {
            popup = true;
            TotalCarb.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Carbs, ";
        }
        if (tCholesterol > uCholesterol)
        {
            popup = true;
            TotalCholesterol.ForeColor = System.Drawing.Color.Red;
            RDAExceed += "Cholesterol, ";
        }
        if (popup)
        {
            alert.Visible = true;
            exceeded.Text = RDAExceed.Remove(RDAExceed.Length - 2, 2);
        }
    }

    protected void exceedClear_click(object sender, EventArgs e)
    {
        alert.Visible = false;
        exceeded.Text = "";
    }

    public void displayFood(FoodItem food, Boolean isDB)
    {
        reset();
        string totalFood = "";
        if (isDB)
        {
            foreach (FoodItem f in existingFood)
            {
                totalFood += f.Name + "-";
                tCal += f.Calories;
                tSatFat += f.Satfat;
                tPolyFat += f.Polyfat;
                tMonoFat += f.Monofat;
                tTransFat += f.Transfat;
                tSodium += f.Sodium;
                tPotassium += f.Potassium;
                tCholesterol += f.Cholesterol;
                tProtein += f.Protein;
                tSugar += f.Sugar;
                tDFibre += f.DFibre;
                tVitA += f.VitA;
                tVitC += f.VitC;
                tCalcium += f.Calcium;
                tIron += f.Iron;
                tCarbo += f.Carbohydrate;

                totalCal.Text = tCal + " kcal";
                totalSatFat.Text = tSatFat + " g";
                TotalPolyFat.Text = tPolyFat + " g";
                TotalMonoFat.Text = tMonoFat + " g";
                TotalTransFat.Text = tTransFat + " g";
                TotalSodium.Text = tSodium + " mg";
                TotalPotassium.Text = tPotassium + " mg";
                TotalCholesterol.Text = tCholesterol + " mg";
                TotalProtein.Text = tProtein + " g";
                TotalSugar.Text = tSugar + " mg";
                TotalDFibre.Text = tDFibre + " g";
                TotalVitA.Text = tVitA + " mg";
                TotalFat.Text = tTotalFat + " mg";
                TotalVitC.Text = tVitC + " mg";
                TotalCalcium.Text = tCalcium + " mg";
                TotalIron.Text = tIron + " mg";
                TotalCarb.Text = tCarbo + " g";

            }
        }
        else if (food != null)
        {
            calories.Text = food.Calories + " kcal";
            satFat.Text = food.Satfat + " g";
            polyFat.Text = food.Polyfat + " g";
            monoFat.Text = food.Monofat + " g";
            tFat.Text = food.TotalFat + " g";
            transFat.Text = food.Transfat + " g";
            sodium.Text = food.Sodium + " mg";
            potassium.Text = food.Potassium + " mg";
            cholesterol.Text = food.Cholesterol + " mg";
            protein.Text = food.Protein + " g";
            sugar.Text = food.Sugar + " mg";
            dFibre.Text = food.DFibre + " g";
            vitA.Text = food.VitA + " mg";
            vitC.Text = food.VitC + " mg";
            carbs.Text = food.Carbohydrate + " g";
            calcium.Text = food.Calcium + " mg";
            iron.Text = food.Iron + " mg";
        }
        else
        {
            foreach (FoodItem fi in foods)
            {
                calories.Text = fi.Calories + " kcal";
                satFat.Text = fi.Satfat + " g";
                polyFat.Text = fi.Polyfat + " g";
                monoFat.Text = fi.Monofat + " g";
                tFat.Text = fi.TotalFat + " g";
                transFat.Text = fi.Transfat + " g";
                sodium.Text = fi.Sodium + " mg";
                potassium.Text = fi.Potassium + " mg";
                cholesterol.Text = fi.Cholesterol + " mg";
                protein.Text = fi.Protein + " g";
                sugar.Text = fi.Sugar + " mg";
                dFibre.Text = fi.DFibre + " g";
                vitA.Text = fi.VitA + " mg";
                vitC.Text = fi.VitC + " mg";
                carbs.Text = fi.Carbohydrate + " g";
                calcium.Text = fi.Calcium + " mg";
                iron.Text = fi.Iron + " mg";
            }
        }
        checkRDA();
    }

    protected void saveFood_Click(object sender, EventArgs e)
    {
        shadow.Visible = true;
        popup_save.Visible = true;
    }

    protected void clearFood_Click(object sender, EventArgs e)
    {
        shadow.Visible = true;
        popup_clear.Visible = true;
        saveFood.Enabled = false;
        clearFood.Enabled = false;
    }
    protected void yesClearClick(object sender, EventArgs e)
    {
        shadow.Visible = false;
        popup_clear.Visible = false;
        reset();
        fromDB.Text = "";
        uFintake.Rows.Clear();
        uFintake.AcceptChanges();
        inf.updateUserFoodInfo(fromDB.Text, username);
        uFintake = inf.viewUserDietInfo(username);
        clearFood.Enabled = false;
        displayFood(null, true);
        Response.Redirect("food.aspx");
    }
    protected void noClearClick(object sender, EventArgs e)
    {
        shadow.Visible = false;
        popup_clear.Visible = false;
        saveFood.Enabled = true;
        clearFood.Enabled = true;
        popup_save.Visible = false;
    }

    protected void save_yes_Click(object sender, EventArgs e)
    {
        fromDB.Text += whatIate.Text;
        whatIate.Text = "";
        foods.Clear();
        reset();
        inf.updateUserFoodInfo(fromDB.Text, username);
        uFintake = inf.viewUserDietInfo(username);
        viewDietInfo();
        displayFood(null, true);
        shadow.Visible = false;
        popup_save.Visible = false;
        saveFood.Enabled = false;
        Response.Redirect("food.aspx");
    }
}