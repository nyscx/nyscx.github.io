using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using DataSetTableAdapters;
/// <summary>
/// Summary description for FoodItem
/// </summary>
public class FoodItem
{
    private string name;
    private NutrientsDBTableAdapter n = new NutrientsDBTableAdapter();
    private double calories = 0, satfat = 0, polyfat = 0, monofat = 0, transfat = 0, sodium = 0, potassium = 0, cholesterol = 0, protein = 0, sugar = 0, dFibre = 0, vitA = 0, vitC = 0, calcium = 0, iron = 0, totalFat = 0, carbohydrate = 0;



    public FoodItem()
    {
    }
    public FoodItem(string foodname)
    {
        if (foodname != null && foodname != "")
        {
            this.name = foodname;
            DataTable dt = n.GetFoodInfoByName(name);
            this.calories = Convert.ToDouble(dt.Rows[0]["Calories"].ToString());
            this.satfat = Convert.ToDouble(dt.Rows[0]["SaturatedFat"].ToString());
            this.polyfat = Convert.ToDouble(dt.Rows[0]["PolyunsaturatedFat"].ToString());
            this.totalFat = Convert.ToDouble(dt.Rows[0]["TotalFat"].ToString());
            this.monofat = Convert.ToDouble(dt.Rows[0]["MonounsaturatedFat"].ToString());
            this.transfat = Convert.ToDouble(dt.Rows[0]["TransFat"].ToString());
            this.sodium = Convert.ToDouble(dt.Rows[0]["Sodium"].ToString());
            this.potassium = Convert.ToDouble(dt.Rows[0]["Potassium"].ToString());
            this.VitA = Convert.ToDouble(dt.Rows[0]["VitA"].ToString());
            this.VitC = Convert.ToDouble(dt.Rows[0]["VitC"].ToString());
            this.carbohydrate = Convert.ToDouble(dt.Rows[0]["Carbohydrate"].ToString());
            this.protein = Convert.ToDouble(dt.Rows[0]["Protein"].ToString());
            this.sugar = Convert.ToDouble(dt.Rows[0]["Sugar"].ToString());
            this.calcium = Convert.ToDouble(dt.Rows[0]["Calcium"].ToString());
            this.iron = Convert.ToDouble(dt.Rows[0]["Iron"].ToString());
            this.dFibre = Convert.ToDouble(dt.Rows[0]["DietaryFibre"].ToString());
            this.cholesterol = Convert.ToDouble(dt.Rows[0]["Cholesterol"].ToString());
        }
    }

    public bool searchFood(string name)
    {
        if (n.GetFoodInfoByName(name) == null)
        {
            return false;
        }
        return true;
    }

    public DataTable getAllFoodName()
    {
        DataTable dt = n.GetAllData();
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dt.AcceptChanges();
        return dt;
    }

    public string getFoodName()
    {
        return this.name;
    }

    public DataTable getFoodByName(string name)
    {
        name = name.Replace("-", "");
        return n.GetFoodInfoByName(name);
    }

    public double[] getFoodNutrients(List<FoodItem> fi)
    {
        return null;
    }

    public DataTable getAllNutrients(List<FoodItem> i)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Name"));
        dt.Columns.Add(new DataColumn("Calories"));
        dt.Columns.Add(new DataColumn("TotalFat"));
        dt.Columns.Add(new DataColumn("Carbohydrate"));
        dt.Columns.Add(new DataColumn("SatFat"));
        dt.Columns.Add(new DataColumn("PolyFat"));
        dt.Columns.Add(new DataColumn("MonoFat"));
        dt.Columns.Add(new DataColumn("TransFat"));
        dt.Columns.Add(new DataColumn("Sodium"));
        dt.Columns.Add(new DataColumn("Potassium"));
        dt.Columns.Add(new DataColumn("Cholesterol"));
        dt.Columns.Add(new DataColumn("Protein"));
        dt.Columns.Add(new DataColumn("Sugar"));
        dt.Columns.Add(new DataColumn("dFibre"));
        dt.Columns.Add(new DataColumn("VitA"));
        dt.Columns.Add(new DataColumn("VitC"));
        dt.Columns.Add(new DataColumn("Calcium"));
        dt.Columns.Add(new DataColumn("Iron"));
        dt.AcceptChanges();
        dt = n.GetAllData();
        return dt;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public double TotalFat
    {
        get
        {
            return totalFat;
        }

        set
        {
            totalFat = value;
        }
    }

    public double Carbohydrate
    {
        get
        {
            return carbohydrate;
        }

        set
        {
            carbohydrate = value;
        }
    }


    public double Calories
    {
        get
        {
            return calories;
        }

        set
        {
            calories = value;
        }
    }

    public double Satfat
    {
        get
        {
            return satfat;
        }

        set
        {
            satfat = value;
        }
    }

    public double Polyfat
    {
        get
        {
            return polyfat;
        }

        set
        {
            polyfat = value;
        }
    }

    public double Monofat
    {
        get
        {
            return monofat;
        }

        set
        {
            monofat = value;
        }
    }

    public double Transfat
    {
        get
        {
            return transfat;
        }

        set
        {
            transfat = value;
        }
    }

    public double Sodium
    {
        get
        {
            return sodium;
        }

        set
        {
            sodium = value;
        }
    }

    public double Potassium
    {
        get
        {
            return potassium;
        }

        set
        {
            potassium = value;
        }
    }

    public double Cholesterol
    {
        get
        {
            return cholesterol;
        }

        set
        {
            cholesterol = value;
        }
    }

    public double Protein
    {
        get
        {
            return protein;
        }

        set
        {
            protein = value;
        }
    }

    public double Sugar
    {
        get
        {
            return sugar;
        }

        set
        {
            sugar = value;
        }
    }

    public double DFibre
    {
        get
        {
            return dFibre;
        }

        set
        {
            dFibre = value;
        }
    }

    public double VitA
    {
        get
        {
            return vitA;
        }

        set
        {
            vitA = value;
        }
    }

    public double VitC
    {
        get
        {
            return vitC;
        }

        set
        {
            vitC = value;
        }
    }

    public double Calcium
    {
        get
        {
            return calcium;
        }

        set
        {
            calcium = value;
        }
    }

    public double Iron
    {
        get
        {
            return iron;
        }

        set
        {
            iron = value;
        }
    }
}