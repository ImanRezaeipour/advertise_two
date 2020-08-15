using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductImage
{

    public class ProductImageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// نام فایل
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string CompanyTitle { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string FileDimension { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string FileSize { get; set; }

        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool IsWatermark { get; set; }

        /// <summary>
        ///  ترتیب عکس
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string ProductCode { get; set; }

        public Guid ProductId { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string ProductImageFileName { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string ProductTitle { get; set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}