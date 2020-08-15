namespace Advertise.Core.Configuration
{
    public interface IConfigurationManager
    {
        string DisplayName { get; }
        string AdminEmail { get; }
        string AdminPassword { get; }
        string AdminUserName { get; }
        string AspNetIdentityRequiredEmail { get; }
        string XsrfKey { get; }
        string PaymentDescription { get; }

        /// <summary>
        /// كد درگاه پرداخت
        /// </summary>
        string MerchantCode { get; }

        /// <summary>
        /// آدرس بازگشت
        /// </summary>
        string PaymentCallbackUrl { get; }

        /// <summary>
        ///  Authority آدرس ارجاع كاربران به وب گيت پس ساخت
        /// </summary>
        string ZarinpalGateway { get; }

        string RedisConnectionString { get; }

        string GoogleCientSecret { get; }
        string GoogleClientId { get; }
        string GoogleSystemEnable { get; }
        string PlanPaymentCallbackUrl { get; }
        string ConfirmationEmailUrl { get; }
        string ConfirmationResetPasswordUrl { get; }
        string SmsUserApiKey { get; }
        string SmsSecretKey { get; }
        string SmsLineNumber { get; }
        string SmsEnabled { get; }
        string VideoWaterMark { get; }

        /// <summary>
        /// 
        /// </summary>
        bool BundleEnabled { get; }

        string BannerPaymentCallbackUrl { get; }
        string AdsPaymentCallbackUrl { get; }
        bool CookieIsLocalhost { get; }
        bool ExportImportUseDropdownlistsForAssociatedEntities { get; }

        /// <summary>
        /// 
        /// </summary>
        string ConnectionString { get; }
    }
}