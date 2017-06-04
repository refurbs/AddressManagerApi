using AutoMapper;
using Demo.AddressManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AddressManager.WebApi
{
    public class ModelMappingProfile: Profile
    {
        /// <summary>
        /// Contructor.
        /// </summary>
        public ModelMappingProfile()
        {
            CreateMap<Contact, ContactModel>()
                .ForMember(c => c.Url,
                options => options.ResolveUsing<ContactUrlResolver>())
                .ReverseMap();
            CreateMap<Contact, ContactWithAddressModel>()
                .ForMember(c => c.Url,
                options => options.ResolveUsing<ContactUrlResolver>())
                .ForMember(c => c.Address,
                options => options.MapFrom(m => m.ContactAddresses.Where(ca => !ca.EndDate.HasValue).FirstOrDefault().Address))
                .ReverseMap();
            CreateMap<Address, AddressModel>()
                .ForMember(c => c.Url,
                options => options.ResolveUsing<AddressUrlResolver>())
                .ReverseMap();
        }
    }
}
