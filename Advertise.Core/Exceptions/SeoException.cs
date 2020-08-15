using System;

namespace Advertise.Core.Exceptions
{

    public sealed class SeoException : Exception
    {
        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        public SeoException(string message) : base(message)
        {
        }

        #endregion Public Constructors
    }
}