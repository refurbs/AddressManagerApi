using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AddressManager
{
    public interface IAddress
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        int Number { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        string Street { get; set; }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>
        /// The town.
        /// </value>
        string Town { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        /// <value>
        /// The post code.
        /// </value>
        string PostCode { get; set; }
    }
}
