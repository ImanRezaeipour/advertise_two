using System;

namespace Advertise.Web.Framework.HiddenFields
{

    public interface IRijndaelStringEncrypter : IDisposable
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Encrypt(string value);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Decrypt(string value);
    }
}