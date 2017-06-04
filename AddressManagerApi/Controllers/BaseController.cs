using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.AddressManager.WebApi
{
    public abstract class BaseController : Controller
    {
        public const string URLROUTE = "URLROUTE";
        
        /// <summary>
        /// Override OnActionExecuting.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            context.HttpContext.Items[URLROUTE] = this.Url;
        }
    }
}
