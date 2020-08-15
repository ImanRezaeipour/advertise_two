using System;

namespace Advertise.Core.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigurationManager : IConfigurationManager
    {
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName => System.Configuration.ConfigurationManager.AppSettings["config:AdminDisplayName"];

        /// <summary>
        /// 
        /// </summary>
        public string AdminEmail => System.Configuration.ConfigurationManager.AppSettings["config:AdminEmail"];

        /// <summary>
        /// 
        /// </summary>
        public string AdminPassword => System.Configuration.ConfigurationManager.AppSettings["config:AdminPassword"];

        /// <summary>
        /// 
        /// </summary>
        public string AdminUserName => System.Configuration.ConfigurationManager.AppSettings["config:AdminUserName"];

        /// <summary>
        /// 
        /// </summary>
        public string AspNetIdentityRequiredEmail => System.Configuration.ConfigurationManager.AppSettings["config:AspNetIdentityRequiredEmail"];

        /// <summary>
        /// 
        /// </summary>
        public string XsrfKey => System.Configuration.ConfigurationManager.AppSettings["config:XsrfKey"];

        /// <summary>
        /// 
        /// </summary>
        public string PaymentDescription => System.Configuration.ConfigurationManager.AppSettings["config:PaymentDescription"];

        /// <summary>
        /// كد درگاه پرداخت
        /// </summary>
        public string MerchantCode => System.Configuration.ConfigurationManager.AppSettings["config:MerchantCode"];

        /// <summary>
        /// آدرس بازگشت
        /// </summary>
        public string PaymentCallbackUrl => System.Configuration.ConfigurationManager.AppSettings["config:PaymentCallbackUrl"];

        /// <summary>
        /// 
        /// </summary>
        public string PlanPaymentCallbackUrl => System.Configuration.ConfigurationManager.AppSettings[ "config:PlanPaymentCallbackUrl"];

        /// <summary>
        /// 
        /// </summary>
        public string BannerPaymentCallbackUrl => System.Configuration.ConfigurationManager.AppSettings[ "config:BannerPaymentCallbackUrl"];

        /// <summary>
        /// 
        /// </summary>
        public string AdsPaymentCallbackUrl => System.Configuration.ConfigurationManager.AppSettings[ "config:AdsPaymentCallbackUrl"];

        /// <summary>
        ///  Authority آدرس ارجاع كاربران به وب گيت پس ساخت
        /// </summary>
        public string ZarinpalGateway => System.Configuration.ConfigurationManager.AppSettings["config:ZarinpalGateway"];

        /// <summary>
        /// 
        /// </summary>
        public string GoogleCientSecret => System.Configuration.ConfigurationManager.AppSettings["oauth:GoogleCientSecret"];

        /// <summary>
        /// 
        /// </summary>
        public string GoogleClientId => System.Configuration.ConfigurationManager.AppSettings["oauth:GoogleClientId"];

        /// <summary>
        /// 
        /// </summary>
        public string GoogleSystemEnable => System.Configuration.ConfigurationManager.AppSettings["oauth:GoogleSystemEnable"];

        /// <summary>
        /// 
        /// </summary>
        public string RedisConnectionString => System.Configuration.ConfigurationManager.AppSettings["redis:ConnectionString"];

        /// <summary>
        /// 
        /// </summary>
        public string RedisEnable => System.Configuration.ConfigurationManager.AppSettings["redis:Enable"];

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmationEmailUrl => System.Configuration.ConfigurationManager.AppSettings["url:ConfirmationEmail"];

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmationResetPasswordUrl => System.Configuration.ConfigurationManager.AppSettings["url:ConfirmationResetPassword"];

        /// <summary>
        /// 
        /// </summary>
        public string SmsEnabled => System.Configuration.ConfigurationManager.AppSettings["sms:Enabled"];

        /// <summary>
        /// 
        /// </summary>
        public string SmsUserApiKey => System.Configuration.ConfigurationManager.AppSettings["sms:UserApiKey"];

        /// <summary>
        /// 
        /// </summary>
        public string SmsSecretKey => System.Configuration.ConfigurationManager.AppSettings["sms:SecretKey"];

        /// <summary>
        /// 
        /// </summary>
        public string SmsLineNumber => System.Configuration.ConfigurationManager.AppSettings["sms:LineNumber"];

        /// <summary>
        /// 
        /// </summary>
        public string VideoWaterMark => System.Configuration.ConfigurationManager.AppSettings["video:WaterMark"];

        /// <summary>
        /// 
        /// </summary>
        public bool BundleEnabled => Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["bundle:Enabled"]);

        /// <summary>
        /// 
        /// </summary>
        public bool CookieIsLocalhost => Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["cookie:IsLocalhost"]);

        /// <summary>
        /// 
        /// </summary>
        public bool ExportImportUseDropdownlistsForAssociatedEntities => true;

        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"].ConnectionString;
    }
}
