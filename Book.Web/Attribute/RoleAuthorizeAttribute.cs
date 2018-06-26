using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Book.Web.Attribute
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuth = false;
            var actionDescriptor = filterContext.ActionDescriptor;
            var conroller = actionDescriptor.ControllerDescriptor.ControllerName;
            var action = actionDescriptor.ActionName;
            var ticket = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket;

            var RoleId = ticket.Version;




            base.OnAuthorization(filterContext);
        }

    }
}