using System.Collections.Generic;

namespace Advertise.Service.Services.Common
{

    public class ServiceResult
    {
        #region Private Fields

        private static readonly ServiceResult _success = new ServiceResult { Succeeded = true };
        private List<string> _errors = new List<string>();

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// An <see cref="IEnumerable{T}" /> of <see cref="string" /> s containing an errors that
        /// occurred during the identity operation.
        /// </summary>
        /// <value> An <see cref="IEnumerable{T}" /> of <see cref="string" /> s. </value>
        public IEnumerable<string> Errors => _errors;

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value> True if the operation succeeded, otherwise false. </value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// Returns an <see cref="ServiceResult" /> indicating a successful identity operation.
        /// </summary>
        /// <returns> An <see cref="ServiceResult" /> indicating a successful operation. </returns>
        public static ServiceResult Success => _success;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Creates an <see cref="ServiceResult" /> indicating a failed identity operation, with a
        /// list of <paramref name="errors" /> if applicable.
        /// </summary>
        /// <param name="errors">
        /// An optional array of <see cref="string" /> s which caused the operation to fail.
        /// </param>
        /// <returns>
        /// An <see cref="ServiceResult" /> indicating a failed identity operation, with a list of
        /// <paramref name="errors" /> if applicable.
        /// </returns>
        public static ServiceResult Failed(params string[] errors)
        {
            var result = new ServiceResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }

        #endregion Public Methods
    }
}