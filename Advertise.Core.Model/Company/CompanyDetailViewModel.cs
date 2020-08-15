using Advertise.Core.Models.Address;
using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyAttachment;
using Advertise.Core.Models.CompanyConversation;
using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Models.CompanyQuestion;
using Advertise.Core.Models.CompanyReview;
using Advertise.Core.Models.CompanyVideo;
using Advertise.Core.Models.Product;
using System;
using System.Collections.Generic;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Company
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }
        public string Alias { get; set; }
        public CompanyAttachmentListViewModel AttachmentList { get; set; }
        public string CategoryAlias { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryOptionViewModel CategoryOption { get; set; }
        public string CategoryTitle { get; set; }
        public string Code { get; set; }
        public IEnumerable<CompanyConversationViewModel> ConversationList { get; set; }
        public string CoverFileName { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public EmployeeRangeType? EmployeeRange { get; set; }
        public DateTime? EstablishedOn { get; set; }
        public string FacebookLink { get; set; }
        public int FollowerCount { get; set; }
        public string FullName { get; set; }
        public string GooglePlusLink { get; set; }
        public Guid Id { get; set; }
        public int ImageCount { get; set; }

        public string CategoryOptionProducts { get; set; }
        public string CategoryOptionCompanies { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool InitFollow { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string InstagramLink { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsMyself { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanyImageViewModel> ImageList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LogoFileName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ProductListViewModel ProductList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public CompanyQuestionListViewModel QuestionList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public CompanyReviewListViewModel ReviewList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int TagCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TelegramLink { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TwitterLink { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserUserName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanyVideoViewModel> VideoList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string YoutubeLink { get; set; }

        #endregion Public Properties
    }
}