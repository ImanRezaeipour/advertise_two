using Advertise.Core.Languages;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Localization;

namespace Advertise.Service.Services.List
{

    public class ListManager : IListManager
    {
        #region Private Fields

        private readonly IResourceService _;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="resourceService"></param>
        public ListManager(IResourceService resourceService)
        {
            _ = resourceService;
        }

        #endregion Public Constructors

        #region Public Methods

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetActiveListAsync()
        //{
        //    var active = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = string.Empty,
        //            Text = "همه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = bool.TrueString,
        //            Text = "فعال"
        //        },
        //        new SelectListItem
        //        {
        //            Value = bool.FalseString,
        //            Text = "غیرفعال"
        //        },
        //    };

        //    return active;
        //}

        //public async Task<IList<SelectListItem>> GetListDayTypeAsync()
        //{
        //    var dayType = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = "0",
        //            Text = "شنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "0",
        //            Text = "شنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "1",
        //            Text = "یکشنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "2",
        //            Text = "دوشنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "3",
        //            Text = "سه شنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "4",
        //            Text = "چهارشنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "5",
        //            Text = "پنجشنبه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "6",
        //            Text = "جمعه"
        //        }
        //    };
        //    return dayType;
        //}

        //public async Task<IList<SelectListItem>> GetCountryAsync()
        //{
        //    var country = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //         Text   = "Iran",
        //         Value = CountryType.Iran.ToString()
        //        }
        //    };

        //    return country;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetWwwRequirementListAsync()
        //{
        //    var list = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = WwwRequirementType.NoMatter.ToString(),
        //            Text = "پیش فرض"
        //        },
        //        new SelectListItem
        //        {
        //            Value = WwwRequirementType.WithWww.ToString(),
        //            Text = "با www باشد"
        //        },
        //        new SelectListItem
        //        {
        //            Value = WwwRequirementType.WithoutWww.ToString(),
        //            Text = "بدون www باشد"
        //        }
        //    };

        //    return list;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetCategoryTypeSelectListItem()
        //{
        //    var selectList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = CategoryType.Salable.ToString(),
        //            Text = "فروشگاهی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = CategoryType.Service.ToString(),
        //            Text = "خدماتی"
        //        }
        //    };

        //    return selectList;
        //}

        //public async Task<IList<SelectListItem>> GetDurationTypeSelectListItem()
        //{
        //    var selectList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = DurationType.OneDay.ToString(),
        //            Text = "یک روزه"
        //        },

        //        new SelectListItem
        //        {
        //            Value = DurationType.TwoDays.ToString(),
        //            Text = "دو روزه"
        //        },

        //        new SelectListItem
        //        {
        //            Value = DurationType.ThreeDays.ToString(),
        //            Text = "سه روزه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = DurationType.OneWeek.ToString(),
        //            Text = "یک هفته"
        //        },
        //        new SelectListItem
        //        {
        //            Value = DurationType.OneMonth.ToString(),
        //            Text = "یک ماهه"
        //        },

        //        //new SelectListItem
        //        //{
        //        //    Value = DurationType.TwoMonths.ToString(),
        //        //    Text = "دو ماهه"
        //        //},

        //        //new SelectListItem
        //        //{
        //        //    Value = DurationType.ThreeMonths.ToString(),
        //        //    Text = "سه ماهه"
        //        //},
        //        //new SelectListItem
        //        //{
        //        //    Value = DurationType.SixMonths.ToString(),
        //        //    Text = "شش ماهه"
        //        //},

        //        //new SelectListItem
        //        //{
        //        //    Value = DurationType.OneYear.ToString(),
        //        //    Text = "یک ساله"
        //        //},
        //    };
        //    return selectList;
        //}

        //public async Task<IList<SelectListItem>> GetPlanDurationTypeSelectItemList()
        //{
        //    var selectList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "سه ماه",
        //            Value = PlanDurationType.ThreeMonth.ToString()
        //        },
        //        new SelectListItem
        //        {
        //            Text = "شش ماه",
        //            Value = PlanDurationType.SixMonth.ToString()
        //        },
        //        new SelectListItem
        //        {
        //            Text = "یک ساله",
        //            Value = PlanDurationType.TwelveMonth.ToString()
        //        }
        //    };
        //    return selectList;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetRedirectionTypeListAsync()
        //{
        //    var selectList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.MovedPermanently.ToString(),
        //            Text = "Moved Permanently"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.Found.ToString(),
        //            Text = "Found"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.MultipleChoices.ToString(),
        //            Text = "Multiple Choices"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.NotModified.ToString(),
        //            Text = "Not Modified"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.PermanentRedirect.ToString(),
        //            Text = "Permanent Redirect"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.SeeOther.ToString(),
        //            Text = "See Other"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.TemporaryRedirect.ToString(),
        //            Text = "Temporary Redirect"
        //        },
        //        new SelectListItem
        //        {
        //            Value = RedirectionType.UseProxy.ToString(),
        //            Text = "Use Proxy"
        //        }
        //    };

        //    return selectList;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public IList<SelectListItem> GetColorType()
        //{
        //    var colorTypes = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = ColorType.None.ToString(),
        //            Text = "بدون رنگ"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Amber.ToString(),
        //            Text = "کهربایی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Blue.ToString(),
        //            Text = "آبی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.BlueGray.ToString(),
        //            Text = "آبی خاکستری"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Brown.ToString(),
        //            Text = "قهوه ای"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Cyan.ToString(),
        //            Text = "فیروزه ای"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.DeepOrange.ToString(),
        //            Text = "نارنجی پررنگ"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.DeepPurple.ToString(),
        //            Text = "بنفش پررنگ"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Gray.ToString(),
        //            Text = "خاکستری"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Green.ToString(),
        //            Text = "سبز"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Indigo.ToString(),
        //            Text = "نیلی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.LightBlue.ToString(),
        //            Text = "آبی روشن"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Lime.ToString(),
        //            Text = "لیمویی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Yellow.ToString(),
        //            Text = "زرد"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Teal.ToString(),
        //            Text = "آبی سیر"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Red.ToString(),
        //            Text = "قرمز"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Purple.ToString(),
        //            Text = "بنفش"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Pink.ToString(),
        //            Text = "صورتی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.Orange.ToString(),
        //            Text = "نارنجی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = ColorType.LightGreen.ToString(),
        //            Text = "سبز روشن"
        //        }
        //    };

        //    return colorTypes;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetIsActiveListAsync()
        //{
        //    var sortDirectionList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = string.Empty,
        //            Text = "همه"
        //        },
        //        new SelectListItem
        //        {
        //            Value = bool.TrueString,
        //            Text = "فعال"
        //        },
        //        new SelectListItem
        //        {
        //            Value = bool.FalseString,
        //            Text = "غیرفعال"
        //        }
        //    };

        //    return sortDirectionList;
        //}


        public async Task<IList<SelectListItem>> GetIsBanListAsync()
        {
            var sortDirectionList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = string.Empty,
                    Text = "همه"
                },
                new SelectListItem
                {
                    Value = bool.TrueString,
                    Text = "قفل شده"
                },
                new SelectListItem
                {
                    Value = bool.FalseString,
                    Text = "قفل نشده"
                }
            };

            return sortDirectionList;
        }


        public async Task<IList<SelectListItem>> GetIsVerifyListAsync()
        {
            var sortDirectionList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = string.Empty,
                    Text = "همه"
                },
                new SelectListItem
                {
                    Value = bool.TrueString,
                    Text = "تائید شده"
                },
                new SelectListItem
                {
                    Value = bool.FalseString,
                    Text = "تائید نشده"
                }
            };

            return sortDirectionList;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetLanguageTypeList()
        //{
        //    var result = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "فارسی",
        //            Value = LanguageType.Persian.ToString()
        //        },
        //        new SelectListItem
        //        {
        //            Text = "انگلیسی",
        //            Value = LanguageType.English.ToString()
        //        }
        //    };

        //    return result;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetPageSizeFilterListAsync()
        //{
        //    var sortList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = "10",
        //            Text = "10 آیتم"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "20",
        //            Text = "20 آیتم"
        //        }
        //    };

        //    return sortList;
        //}


        public async Task<IList<SelectListItem>> GetPageSizeListAsync()
        {
            var pageSizeList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = PageSize.Count10.ToString(),
                    Text = "10"
                },
                new SelectListItem
                {
                    Value = PageSize.Count20.ToString(),
                    Text = "20"
                },
                new SelectListItem
                {
                    Value = PageSize.Count30.ToString(),
                    Text = "30"
                },
                new SelectListItem
                {
                    Value = PageSize.Count50.ToString(),
                    Text = "50"
                },
                new SelectListItem
                {
                    Value = PageSize.Count100.ToString(),
                    Text = "100"
                },
                new SelectListItem
                {
                    Value = "10000",
                    Text = "همه"
                }
            };

            return pageSizeList;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetPeymentListAsync()
        //{
        //    var peymentList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = "1",
        //            Text = "پرداخت اینترنتی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "2",
        //            Text = "پرداخت در محل"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "3",
        //            Text = "پرداخت کارت به کارت"
        //        }
        //    };

        //    return peymentList;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<List<SelectListItem>> GetSellTypeListAsync()
        //{
        //    var sortList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = SellType.Available.ToString(),
        //            Text = Admin.ProductStateAvailabel
        //        },
        //        new SelectListItem
        //        {
        //            Value = SellType.Unavailable.ToString(),
        //            Text = Admin.ProductStateUnavailabel
        //        },
        //        new SelectListItem
        //        {
        //            Value = SellType.Soon.ToString(),
        //            Text = Admin.ProductStateSoon
        //        },
        //        new SelectListItem
        //        {
        //            Value = SellType.Hidden.ToString(),
        //            Text = Admin.ProductStateUnsell
        //        }
        //    };

        //    return sortList;
        //}

        //public async Task<IList<SelectListItem>> GetAdsType()
        //{
        //    var type = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = "1",
        //            Text = "بنر"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "2",
        //            Text = "اسلاید"
        //        }
        //    };
        //    return type;
        //}

        //public async Task<IList<SelectListItem>> GetAdsPositionType()
        //{
        //    var type = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = "1",
        //            Text = "صفحه اصلی"
        //        },
        //        new SelectListItem
        //        {
        //            Value = "2",
        //            Text = "دسته بندی"
        //        }
        //    };
        //    return type;
        //}


        public async Task<IList<SelectListItem>> GetSortDirectionFilterListAsync()
        {
            var sortList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "asc",
                    Text = "صعودی"
                },
                new SelectListItem
                {
                    Value = "desc",
                    Text = "نزولی"
                }
            };

            return sortList;
        }


        public async Task<IList<SelectListItem>> GetSortDirectionListAsync()
        {
            var sortDirectionList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = SortDirection.Asc,
                    Text = "صعودی"
                },
                new SelectListItem
                {
                    Value = SortDirection.Desc,
                    Text = "نزولی"
                }
            };

            return sortDirectionList;
        }


        public async Task<IList<SelectListItem>> GetSortMemberFilterListAsync()
        {
            var sortList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "price",
                    Text = "قیمت"
                },
                new SelectListItem
                {
                    Value = "createdon",
                    Text = "جدیدترین"
                }
            };

            return sortList;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetMeetTypeAsSelectListItemAsync()
        //{
        //    var list = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "نمایشگاه",
        //            Value = "1"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "مهمان",
        //            Value = "2"
        //        }
        //    };

        //    return list;
        //}


        //public async Task<IList<SelectListItem>> GetSortMemberListAsync()
        //{
        //    var sortList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = SortMember.CreatedOn,
        //            Text = "تاریخ درج"
        //        },
        //        new SelectListItem
        //        {
        //            Value = SortMember.ModifiedOn,
        //            Text = "آخرین تغییر"
        //        }
        //    };

        //    return sortList;
        //}


        public async Task<IList<SelectListItem>> GetSortMemberListByTitleAsync()
        {
            var sortMemberList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = SortMember.CreatedOn,
                    Text = "تاریخ درج"
                },
                new SelectListItem
                {
                    Value = SortMember.ModifiedOn,
                    Text = "آخرین تغییر"
                },
                new SelectListItem
                {
                    Value = SortMember.Title,
                    Text = "نام"
                }
            };

            return sortMemberList;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetStateListAsync()
        //{
        //    var stateList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "همه",
        //            Value = "-1"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "تائید شده",
        //            Value = "1"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "درحال بررسی",
        //            Value = "2"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "رد شده",
        //            Value = "3"
        //        },
        //    };

        //    return stateList;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetStateTypeListAsync()
        //{
        //    var stateList = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Value = StateType.ApproveAjax.ToString(),
        //            Text = "تایید شده"
        //        },
        //        new SelectListItem
        //        {
        //            Value = StateType.RejectAjax.ToString(),
        //            Text = "رد شده"
        //        },
        //        new SelectListItem
        //        {
        //            Value = StateType.Pending.ToString(),
        //            Text = "منتظر"
        //        }
        //    };

        //    return stateList;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetThemeTypeList()
        //{
        //    var result = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "آبی",
        //            Value = ThemeType.Blue.ToString()
        //        },
        //        new SelectListItem
        //        {
        //            Text = "سفید",
        //            Value = ThemeType.White.ToString()
        //        }
        //    };

        //    return result;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetTypeGenderList()
        //{
        //    var result = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "مرد",
        //            Value = GenderType.Male.ToString()
        //        },
        //        new SelectListItem
        //        {
        //            Text = "زن",
        //            Value = GenderType.Female.ToString()
        //        }
        //    };

        //    return result;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IList<SelectListItem>> GetTypSpecificationeList()
        //{
        //    var result = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "چند انتخابی",
        //            Value = "1"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "رنگ",
        //            Value = "2"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "تک انتخابی",
        //            Value = "3"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "لیست کشویی",
        //            Value = "4"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "مبلغ",
        //            Value = "5"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "رشته",
        //            Value = "6"
        //        }
        //    };

        //    return result;
        //}

        ///// <summary>
        ///// لیست روش های تسویه حساب
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<SelectListItem> GetClearingTypeList()
        //{
        //    var list = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "هفتگی",
        //            Value = "1"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "ماهانه",
        //            Value = "2"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "اعلام توسط تماس تلفنی",
        //            Value = "3"
        //        },
        //        new SelectListItem
        //        {
        //            Text = "بالاتر از سقف مشخص شده",
        //            Value = "4"
        //        }
        //    };

        //    return list;
        //}

        #endregion Public Methods
    }
}