using System.Web;
using System.Web.Mvc;

namespace NorthWNDweb.Custom
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly int _Role;
        public SecurityFilter( int Role)
        {
            _Role = Role;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["Role"] is null || (session["Role"] != null && (int)session["Role"] < _Role))
            {
               filterContext.Result = new RedirectResult("/Account/Login", false);
            }

            base.OnActionExecuted(filterContext);
        }

    }
}