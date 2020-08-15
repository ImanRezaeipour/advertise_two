using Advertise.Core.Models.UserOperator;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Plans;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Accounts
{

    public class AccountFactory : IAccountFactory
    {
        #region Private Fields

        private readonly IListManager _listManager;
        private readonly IPlanService _planService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="planService"></param>
        /// <param name="listManager"></param>
        public AccountFactory(IPlanService planService, IListManager listManager)
        {
            _planService = planService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<UserOperatorCreateViewModel> PrepareUserOperatorCreateViewModel(UserOperatorCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new UserOperatorCreateViewModel();
            viewModel.RoleList = await _planService.GetAllAsSelectListItemAsync();
            viewModel.PaymentTypeList = EnumHelper.CastToSelectListItems<PaymentType>();//await _listManager.GetPeymentListAsync();


            return viewModel;
        }

        #endregion Public Methods
    }
}