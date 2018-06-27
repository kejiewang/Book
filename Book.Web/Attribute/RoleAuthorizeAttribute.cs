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

            Book.BLL.T_Base_Home bllHome = new BLL.T_Base_Home();
            List<Book.Model.T_Base_Menu> lst = bllHome.GetMenuList(RoleId, conroller, action);

            if (lst.Count >= 1)
            {
                isAuth = true;
            }
            if (!isAuth)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { controller = "home", action = "login" }
                        )
                    );
            }

            base.OnAuthorization(filterContext);
        }

    }
}