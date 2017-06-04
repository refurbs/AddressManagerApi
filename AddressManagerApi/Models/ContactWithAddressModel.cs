using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.AddressManager;

namespace Demo.AddressManager.WebApi
{
    /// <summary>
    /// The Contact object
    /// </summary>
    public class ContactWithAddressModel: ContactModel
    {
        /// <summary>
        /// Gets or sets the associated address relationships.
        /// </summary>
        public AddressModel Address { get; set; }

    }
}
