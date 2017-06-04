using AutoMapper;
using Demo.AddressManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AddressManager.WebApi
{
    public class ContactUrlResolver : IValueResolver<Contact, ContactModel, string>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ContactUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Contact source, ContactModel destination, string destMember, ResolutionContext context)
        {
            var helper = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLROUTE];
            return helper.Link("ContactGet", new { id = source.Id });
        }
    }

}
