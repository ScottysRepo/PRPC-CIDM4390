using System;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PRPC_CIDM4390.Models
{
  [HttpPost]
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
    