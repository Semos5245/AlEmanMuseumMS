using System.Collections.Generic;

namespace ALEmanMuseum.Services.ServicesResponse
{
    /// <summary>
    /// Represents a service error with type <see cref="TError"/>
    /// </summary>
    /// <typeparam name="TError">Type of error</typeparam>
    public class ServiceError<TError>
    {
        #region Public Properties
        
        /// <summary>
        /// The error by the service
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// The type of the error
        /// </summary>
        public TError ErrorType { get; }

        /// <summary>
        /// The additional info for the error
        /// </summary>
        public Dictionary<string, object> AdditionalInfo { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceError(string error = null, TError errorType = default, Dictionary<string, object> additionalInfo = null) 
            => (ErrorMessage, ErrorType, AdditionalInfo) 
            = (error, errorType, additionalInfo ?? new Dictionary<string, object>());

        #endregion
    }
}
