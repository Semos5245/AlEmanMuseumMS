using System;
using System.Collections.Generic;
using System.Text;

namespace ALEmanMuseum.Core.Enums
{
    /// <summary>
    /// States of a checkout
    /// </summary>
    public enum CheckoutStatus
    {
        /// <summary>
        /// Still processing
        /// Helper for excluding from profits calculations
        /// </summary>
        Processing = 1,

        /// <summary>
        /// Checkout done and confirmed
        /// </summary>
        Confirmed = 2
    }
}
