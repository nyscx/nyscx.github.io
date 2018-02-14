using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Mail;

/// <summary>
/// Summary description for DietaryData
/// </summary>
public class EmailServer
{
    SmtpClient client = new SmtpClient();
    public EmailServer()
    {
        client.Port = 587;
        client.Host = "smtp.live.com";
        client.EnableSsl = true;
        client.Timeout = 10000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("cz2002-mystars@hotmail.com", "zxc123zxc");
    }

    public void sendMail(string address, string username)
    {
        try
        {
            MailMessage mm = new MailMessage("cz2002-mystars@hotmail.com", address, "Registration Success!", "Dear " + username + ",\nYou have successfully created an account with HEALTHSYS");
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
            mm.Dispose();
        }catch(Exception ex)
        {

        }
    }
}