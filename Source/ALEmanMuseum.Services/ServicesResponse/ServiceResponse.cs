using ALEmanMuseum.Core;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace ALEmanMuseum.Services.ServicesResponse
{
    /// <summary>
    /// Represents a response for retrieving an entity of type <see cref="TEntity"/> 
    /// with the related error of type <see cref="TError"/>
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TError">Type of error</typeparam>
    public class EntityResponse<TEntity, TError> : ServiceResponse<TError> where TEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The entity that has been returned
        /// </summary>
        public TEntity Entity { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="error">Error returned by the service</param>
        /// <param name="entity">Entity returned by the service</param>
        public EntityResponse(ServiceError<TError> error = null, TEntity entity = null)
            // Call base 
            : base(error ?? new ServiceError<TError>())
            // Do custom construction
            => Entity = entity;

        #endregion
    }

    /// <summary>
    /// Represents a response for retrieving a collection of entities of type <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Type of entities</typeparam>
    public class EntitiesResponse<TEntity, TError> : ServiceResponse<TError> where TEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The collection of entities that have been returned
        /// </summary>
        public IEnumerable<TEntity> Entities { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="entities">Entities retrieved</param>
        /// <param name="error">Error returned by the service</param>
        public EntitiesResponse(IEnumerable<TEntity> entities = null, ServiceError<TError> error = null)
            // Call base
            : base(error ?? new ServiceError<TError>())
            // Do custom construction
            => Entities = entities;

        #endregion
    }

    /// <summary>
    /// Represents the response data from the service with a related error type
    /// </summary>
    /// <typeparam name="TError">Type of error</typeparam>
    public class ServiceResponse<TError>
    {
        #region Public Properties

        /// <summary>
        /// Indicator whether the response is successful or not
        /// </summary>
        public bool Success => Error == null || EqualityComparer<TError>.Default.Equals(Error.ErrorType, default);

        /// <summary>
        /// The error if there are any
        /// </summary>
        public ServiceError<TError> Error { get; } = default;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ServiceResponse(ServiceError<TError> error = default) => Error = error;

        #endregion

        #region Public Methods

        public string LocalizedError(IStringLocalizer localizer)
            => localizer[Error.ErrorMessage].Value;

        #endregion
    }
}
