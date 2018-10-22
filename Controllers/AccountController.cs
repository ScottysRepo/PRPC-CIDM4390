using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRPC_CIDM4390.Models;
using System;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace PRPC_CIDM4390.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
       public static string  EconfUser {get; set;}
       public static string  connection = GetConnectionString("DefaultConnection"); 
       public static string  command = null;

       public static string parameterName = null;
       public static string methodName = null;
       string codeType = null;
    
    
    //Method to get Connection string
    public static string GetConnectionString(string connection)
    {
        return ConfigurationManager.ConnectionStrings[connection].ConnectionString;
    }
    
    public static async Task<string> EmailTemplate(string template)
    {
        var templateFilePath = HostingEnvironment.MapPath("")
    }
    //Method to check username or email in our database
    // and return a string
    public static string ReturnString (string str)
    {
        string strOut = null;
        using (SqlConnection myConnection = new SqlConnection(connection))
        using (SqlCommand cmd = new SqlCommand(command, myConnection))
        {
            cmd.Parameters.AddWithValue(parameterName, str);
            myConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                       if (methodName == "FindEmail")
                       {
                           strOut = reader["Email"].ToString();
                       }
                       else if (methodName == "FindUserName")
                       {
                           strOut = reader["UserName"].ToString();
                       } 
                       
                    }
                    myConnection.Close();
                }
                return strOut;
            }
        }
    }

        //Methods that user either email or username to check if a user 
        //is in the database. 
        public static string FindEmail(string email)
        {
            command = "SELECT Email AS Email FROM ApplicationUser WHERE Email = @Email";
            parameterName = "@Email";
            methodName = "FindEmail";
            return ReturnString (email);
        }
        public static string FindUserName(string username)
        {
            command = "SELECT UserName AS UserName FROM ApplicationUser WHERE UserName = @UserName";
            parameterName = "@UserName";
            methodName = "FindUserName";
            return ReturnString (username);
        }
        //Check if the username is confirmed and return a boolean
        public bool ReturnBool(string str)
        {
            bool econfOut = false;
            string res = null;
            using (SqlConnection myConnection = new SqlConnection (connection))
            using (SqlCommand cmd = new SqlCommand(command,myConnection))
            {
                cmd.Parameters.AddWithValue (parameterName, str);
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            res = reader["EmailConfirmed"].ToString();
                            if (res == "False")
                            {
                                econfOut = false;
                            }
                            else 
                            {
                                econfOut = true;
                            }
                        }
                        myConnection.Close();
                    }
                    return econfOut;
                }
            }
        }
        //Methods that confrim email by either username and user id 
        public bool EmailConfirmation (string username)
        {
            command= "SELECT EmailConfirmed as EmailConfirmed from ApplicationUser where UserName =@UserName";
            parameterName = "@UserName";
            return ReturnBool(username);
        }
        public bool EmailConfirmationbyId (string userid)
        {
            command= "SELECT EmailConfirmed as EmailConfirmed from ApplicationUser where Id =@Id";
            parameterName = "@UserName";
            return ReturnBool(userid);
        }
        public static int UpdateDatabase (string username)
        {
            using (SqlConnection myConnection = new SqlConnection (connection))
            using (SqlCommand cmd = new SqlCommand(command, myConnection))
            {
                cmd.Parameters.AddWithValue(parameterName, username);
                myConnection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

 /*    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(Registration model)
    {
        if (ModelState.IsValid)
        {
        var user = new ApplicationUser { UserName = model.username, Email = model.email };
        var result = await UserManager.CreateAsync(user, model.password);
        if (result.Succeeded)
        {
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var callbackUrl = Url.Action(
               "ConfirmEmail", "Account", 
               new { userId = user.Id, code = code }, 
               protocol: Request.Url.Scheme);

            await UserManager.SendEmailAsync(user.Id, 
               "Confirm your account", 
               "Please confirm your account by clicking this link: <a href=\"" 
                                               + callbackUrl + "\">link</a>");
            // ViewBag.Link = callbackUrl;   // Used only for initial demo.
            return View("DisplayEmail");
        }
        AddErrors(result);
    }

    // If we got this far, something failed, redisplay form
    return View(model);
    }
    }
}
*/
