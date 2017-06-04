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
    public class ContactModel: IContact
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

    }
}
