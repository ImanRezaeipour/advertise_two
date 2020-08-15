using System.Xml;

namespace Advertise.Service.Services.ExportImport
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="nodeName"></param>
        /// <param name="nodeValue"></param>
        /// <param name="ignore"></param>
        /// <param name="defaulValue"></param>
        public static void WriteString(this XmlWriter xmlWriter, string nodeName, object nodeValue, bool ignore = false, string defaulValue = "")
        {
            if (ignore) return;
            xmlWriter.WriteElementString(nodeName, nodeValue == null ? defaulValue : nodeValue.ToString());
        }
    }
}
