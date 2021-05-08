using CollegeManagement.DTO.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public AuthorizeAttribute()
    {
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var account = (AccountLogin)context.HttpContext.Items["UserLogin"];

        if (account == null)
        {
            context.Result = new RedirectToActionResult("Index", "Auth", new { area = "Admin" });
        }
    }
}