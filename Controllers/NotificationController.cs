using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRPC_CIDM4390.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;

namespace PRPC_CIDM4390.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
       private readonly IConfiguration _configuration;
       //private readonly UserManager<Rider> userManager;
        private readonly RiderDb _context;
       public NotificationController(IConfiguration configuration)
       {
         _configuration = configuration;
       }      
        public NotificationController(RiderDb context)
        {
            _context = context;
        }
        /* public NotificationController (UserManager<Rider> userManager)
        {
            this.userManager = userManager;
        } 
*/
       [Route("SendNotification")]
       public async Task PostMessage()
       {
          var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
          var client = new SendGridClient(apiKey);
          var from = new EmailAddress("test1@example.com", "Example User 1");
          List<EmailAddress> tos = new List<EmailAddress>
          {
              new EmailAddress("test2@example.com", "Example User 2"),
              new EmailAddress("test3@example.com", "Example User 3"),
              new EmailAddress("test4@example.com","Example User 4")
          };

          var subject = "Hello world email from Sendgrid ";
          var htmlContent = "<strong>Hello world with HTML content</strong>";
          var displayRecipients = false; // set this to true if you want recipients to see each others mail id 
          var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);
          var response = await client.SendEmailAsync(msg);
      }

[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Register(Register model)
{
    if (ModelState.IsValid)
    {
        var user = new Rider { UserName = model.EmailAddress, Email = model.EmailAddress };
        var result = await _context.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            var code = await _context.GenerateEmailConfirmationTokenAsync(user.userId);
            var callbackUrl = Url.Action(
               "ConfirmEmail", "Account", 
               new { userId = user.userId, code = code }, 
               protocol: Request.Url.Scheme);

            await _context.SendEmailAsync(user.userId, 
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

      public async Task <IActionResult> ConfirmEmail(string userId, DateTime date, string code)
      {
          if (userId == null )
          {
              return NotFound();
          }

          var user = await _context.FindByIdAsync(userId);
          if (user == null || date != null)
          { 
            if (date.AddMinutes(1)<DateTime.Now)
              {
                  return RedirectToAction("Confirmation Link has Expired");
              }
              else 
              {
                  var result = await _context.ConfirmEmailAsync(user);
                  return View(result.Succeded);
              }
          }
          else
          {
              return View("Error");
          }
      }
   }
}