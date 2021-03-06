using System.Web;
using Advertise.Service.Managers.Cookie;

namespace Advertise.Web.Framework.Providers.SessionProvider
{

    public class BaseSessionProvider : ISessionProvider
    {
        private readonly HttpContextBase _httpContextBase;

        /// <summary>
        /// </summary>
        /// <param name="httpContextBase"></param>
        public BaseSessionProvider(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return null;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            return CookieExtention.DeserializeCookie<T>(_httpContextBase.GetCookieValue(key));
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            _httpContextBase.RemoveCookie(key);
        }

        /// <summary>
        /// </summary>
        public void RemoveAll()
        {
            _httpContextBase.RemoveAllCookies();
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Store<T>(string key, T value) where T : class
        {
            _httpContextBase.AddCookie(key, CookieExtention.SerializeToBase64EncodedString(value));
        }
    }
}