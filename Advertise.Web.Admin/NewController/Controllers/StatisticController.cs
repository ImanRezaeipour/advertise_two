using Advertise.Core.Models.Statistic;
using Advertise.Service.Services.Statistics;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class StatisticController : Controller
    {
        #region Private Fields

        private readonly IStatisticService _statisticService;

        #endregion Private Fields

        #region Public Constructors


        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> List()
        {
            var viewModel = new StatisticListViewModel();
            return View(MVC.Statistic.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}