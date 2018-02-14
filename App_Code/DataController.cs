using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;
using DataSetTableAdapters;


/// <summary>
/// Summary description for DataController
/// </summary>
public class DataController
{
    public const int keySize = 256;
    public const int derIterations = 1000;
    public UserDBTableAdapter user = new UserDBTableAdapter();
    public NutrientsDBTableAdapter nutrient = new NutrientsDBTableAdapter();

    public DataController()
    {
    }

    public string Encrypt(string toEnc, bool useHashing)
    {
        byte[] keyArray;
        byte[] toEncArray = UTF8Encoding.UTF8.GetBytes(toEnc);
        string key = "GOODJOBGOODJOBGOODJOB123";
        if (useHashing)
        {
            MD5CryptoServiceProvider sh = new MD5CryptoServiceProvider();
            keyArray = sh.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            sh.Clear();
        }
        else
        {
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
        }

        TripleDESCryptoServiceProvider td = new TripleDESCryptoServiceProvider();
        td.Key = keyArray;
        td.Mode = CipherMode.ECB;
        td.Padding = PaddingMode.PKCS7;

        ICryptoTransform cT = td.CreateEncryptor();
        byte[] resultArray = cT.TransformFinalBlock(toEncArray, 0, toEncArray.Length);
        td.Clear();

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public bool validate(string username, string pass)
    {
        DataTable dt = user.GetValidationDetails(username);
        pass = Encrypt(pass, false);
        if(dt.Rows.Count == 0)
        {
            return false;
        }
        else
        {
            if(pass == dt.Rows[0]["Password"].ToString())
            {
                return true;
            }
            return false;
        }
    }

    public bool createUser(string username, string password, string healthProblems, string gender, string poscod, string birthdate, string email)
    {
        DateTime d = new DateTime();
        if (DateTime.TryParse(birthdate, out d))
        {
            user.createUser(username, Encrypt(password, false), healthProblems, gender, d.ToShortDateString(), poscod, null, email);
            return true;
        }
        return false;
    }

    public bool checkUserExists(string username)
    {
        DataTable dt = user.GetData();
        for(int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["username"].ToString().Equals(username))
            {
                return true;
            }
        }
        return false;
    }

   
}