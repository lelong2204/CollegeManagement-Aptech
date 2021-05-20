using CollegeManagement.DTO.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private string _RoleType;
    public string RoleType
    {
        get { return _RoleType.ToUpper(); }
        set
        {
            _RoleType = value;
        }
    }

    public AuthorizeAttribute()
    {
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var account = (AccountLogin)context.HttpContext.Items["UserLogin"];

        if (account == null)
        {
            context.HttpContext.Response.Redirect("/Admin/Auth");
        }

        if (_RoleType != null && _RoleType.Length > 0 && account != null && !_RoleType.Contains(account.Role))
        {
            context.HttpContext.Response.Redirect("/Admin/NotFound");
        }
    }
}