using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AddressManager
{
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        long Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string UserName { get; set; }
    }
}
