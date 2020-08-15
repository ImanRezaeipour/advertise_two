using System;
using System.Linq;
using System.Web;

namespace Advertise.Service.Services.Seo
{
    /// <summary>
    ///     Normalize the Url for Check Are Same with other Url
    /// </summary>
    public static class NormalizationUrl
    {
        /// <summary>
        /// </summary>
        public static readonly string[] DefaultDirectoryIndexes =
        {
            "default.asp",
            "default.aspx",
            "index.htm",
            "index.html",
            "index.php"
        };

        /// <summary>
        /// </summary>
        /// <param name="url1"></param>
        /// <param name="url2"></param>
        /// <returns></returns>
        public static bool AreTheSameUrls(this string url1, string url2)
        {
            url1 = url1.NormalizeUrl();
            url2 = url2.NormalizeUrl();
            return url1.Equals(url2);
        }

        /// <summary>
        /// </summary>
        /// <param name="uri1"></param>
        /// <param name="uri2"></param>
        /// <returns></returns>
        public static bool AreTheSameUrls(this Uri uri1, Uri uri2)
        {
            var url1 = uri1.NormalizeUrl();
            var url2 = uri2.NormalizeUrl();
            return url1.Equals(url2);
        }

        /// <summary>
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string NormalizeUrl(this Uri uri)
        {
            var url = UrlToLower(uri);
            url = LimitProtocols(url);
            url = RemoveDefaultDirectoryIndexes(url);
            url = RemoveTheFragment(url);
            url = RemoveDuplicateSlashes(url);
            url = AddWww(url);
            url = RemoveFeedburnerPart(url);
            return RemoveTrailingSlashAndEmptyQuery(url);
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string NormalizeUrl(this string url)
        {
            return NormalizeUrl(new Uri(url));
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string RemoveFeedburnerPart(string url)
        {
            var idx = url.IndexOf("utm_source=", StringComparison.Ordinal);
            return idx == -1 ? url : url.Substring(0, idx - 1);
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string AddWww(string url)
        {
            if (new Uri(url).Host.Split('.').Length == 2 && !url.Contains("://www."))
            {
                return url.Replace("://", "://www.");
            }
            return url;
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string RemoveDuplicateSlashes(string url)
        {
            var path = new Uri(url).AbsolutePath;
            return path.Contains("//") ? url.Replace(path, path.Replace("//", "/")) : url;
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string LimitProtocols(string url)
        {
            return new Uri(url).Scheme == "https" ? url.Replace("https://", "http://") : url;
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string RemoveTheFragment(string url)
        {
            var fragment = new Uri(url).Fragment;
            return string.IsNullOrWhiteSpace(fragment) ? url : url.Replace(fragment, string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static string UrlToLower(Uri uri)
        {
            return HttpUtility.UrlDecode(uri.AbsoluteUri.ToLowerInvariant());
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string RemoveTrailingSlashAndEmptyQuery(string url)
        {
            return url
                .TrimEnd('?')
                .TrimEnd('/');
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string RemoveDefaultDirectoryIndexes(string url)
        {
            foreach (var index in DefaultDirectoryIndexes.Where(index => url.EndsWith(index)))
            {
                url = url.TrimEnd(index.ToCharArray());
                break;
            }
            return url;
        }
    }
}