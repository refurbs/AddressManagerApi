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
    public class AddressUrlResolver : IValueResolver<Address, AddressModel, string>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public AddressUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Address source, AddressModel destination, string destMember, ResolutionContext context)
        {
            var helper = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLROUTE];
            return helper.Link("AddressGet", new { Id = source.Id});
        }
    }

}
