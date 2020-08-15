using System;

namespace Advertise.Web.Framework.Noty
{

    [Serializable]
    public class NotyMessage
    {
        /// <summary>
        /// </summary>
        public NotyAlertType Type { get; set; }

        /// <summary>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// </summary>
        public NotyAnimationType CloseAnimation { get; set; }

        /// <summary>
        /// </summary>
        public NotyAnimationType OpenAnimation { get; set; }

        /// <summary>
        /// </summary>
        public int AnimateSpeed { get; set; }

        /// <summary>
        ///     gets or sets value indicating whether this message hast timeout(false)
        /// </summary>
        public bool IsSticky { get; set; }

        /// <summary>
        /// </summary>
        public NotyMessageCloseType CloseWith { get; set; }

        /// <summary>
        /// </summary>
        public NotyMessageLocationType Location { get; set; }

        /// <summary>
        /// </summary>
        public bool IsSwing { get; set; }

        /// <summary>
        /// </summary>
        public bool IsKiller { get; set; }

        /// <summary>
        /// </summary>
        public bool IsForce { get; set; }

        /// <summary>
        /// </summary>
        public bool IsModal { get; set; }
    }
}