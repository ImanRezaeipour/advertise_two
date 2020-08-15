namespace Advertise.Web.Framework.HiddenFields
{

    public interface IEncryptSettingsProvider
    {
        /// <summary>
        /// </summary>
        byte[] EncryptionKey { get; }

        /// <summary>
        /// </summary>
        string EncryptionPrefix { get; }
    }
}