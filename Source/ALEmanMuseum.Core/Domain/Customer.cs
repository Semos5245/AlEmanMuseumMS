﻿using ALEmanMuseum.Core.Enums;
using System;
using System.Collections.Generic;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a customer in the application
    /// </summary>
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Favorites = new List<Favorite>();
        }

        #region Properties

        /// <summary>
        /// The name of the customer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the profile picture path
        /// </summary>
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the birth date
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or set the blocked flag
        /// </summary>
        public bool Blocked { get; set; }

        /// <summary>
        /// Gets or sets the gender identifier
        /// </summary>
        public int GenderId { get; set; } = (int)Gender.Male;

        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// The user id generated by EfCore identity
        /// </summary>
        public string UserId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related country
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Navigation Property to the related favorite
        /// </summary>
        public virtual ICollection<Favorite> Favorites { get; set; }

        #endregion
    }
}
