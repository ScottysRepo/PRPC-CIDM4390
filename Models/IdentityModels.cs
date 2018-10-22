using System;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public async Task<ActionResult> ConfirmEmail(string userId, DateTime date, string code)
{
    if (userId == null || code == null)
    {
        return View ("Error")
    }
    var user = await UserManager.FindByIdAsync (userId);
    if (user == null)
    {
        return RedirectToAction("ConfirmationLinkExpired", "Account");
    }
    var emailConf = EmailConfirmationById(userId);
    if (emailConf == true)
    {
        return RedirectToAction("ConfirmationLinkUsed", "Account");
    }
    if (date !=null)
    {
        if(date.AddMinutes(1) < DateTime.Now )
        {
            return RedirectToAction("ConfirmationExpired", "Account");
        }
        else 
        {
            var result = await UserManager .ConfirmEmailAsync(userId, code);
            return View (result.Succeeded ? "ConfirmEmail": "Error");
        }
    }
    else 
    {
        return View("Error");
    }
}