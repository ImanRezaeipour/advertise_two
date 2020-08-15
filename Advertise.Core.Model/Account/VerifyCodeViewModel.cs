namespace Advertise.Core.Models.Account
{

    public class VerifyCodeViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool RememberBrowser { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ReturnUrl { get; set; }

        #endregion Public Properties
    }
}