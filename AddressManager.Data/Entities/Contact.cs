using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.AddressManager;

namespace Demo.AddressManager.Data
{
    /// <summary>
    /// The Contact object
    /// </summary>
    public class Contact: IContact
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

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

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The expired date.
        /// </value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The expired date.
        /// </value>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the associated address relationships.
        /// </summary>
        public IEnumerable<ContactAddress> ContactAddresses { get; set; }

    }
}
