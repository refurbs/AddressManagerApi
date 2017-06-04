using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AddressManager.Data
{
    public class ContactAddress
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long ContactId { get; set; }

        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the address id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long AddressId { get; set; }

        public Address Address { get; set; }

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
    }
}
