using Advertise.Core.Domains.Reports;
using Advertise.Core.Models.Report;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Configuration;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Service.Managers.Kendo.DynamicLinq;
using AutoMapper.QueryableExtensions;

namespace Advertise.Service.Services.Reports
{

    public class ReportService : IReportService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IDbSet<Report> _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;
        private readonly IConfigurationManager _configurationManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="unitOfWork"></param>
        ///  <param name="mapper"></param>
        /// <param name="webContextManager"></param>
        public ReportService(IUnitOfWork unitOfWork, IMapper mapper, IWebContextManager webContextManager, IConfigurationManager configurationManager)
        {
            _unitOfWork = unitOfWork;
            _reportRepository = unitOfWork.Set<Report>();
            _mapper = mapper;
            _webContextManager = webContextManager;
            _configurationManager = configurationManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task CreateByViewModelAsync(ReportCreateViewModel viewModel)
        {
            var report = _mapper.Map<Report>(viewModel);
            if (viewModel.ContentFile != null)
            {
                 var buffer = new byte[viewModel.ContentFile.InputStream.Length];
                 viewModel.ContentFile.InputStream.Read(buffer, 0, buffer.Length);
                 report.Content = Encoding.UTF8.GetString(buffer);
            }
           
            report.CreatedById = _webContextManager.CurrentUserId;
            _reportRepository.Add(report);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid reportId)
        {
            var report = await FindByIdAsync(reportId);
            _reportRepository.Remove(report);

            await _unitOfWork.SaveAllChangesAsync();
        }


        public async Task EditByViewModelAsync(ReportEditViewModel viewModel)
        {
            var report = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, report);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task<Report> FindByIdAsync(Guid reportId)
        {
            return await _reportRepository.SingleOrDefaultAsync(model => model.Id == reportId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task<StiReport> GetReportAsStiReportAsync(Guid reportId, ReportParameterViewModel viewModel)
        {
            var report = await FindByIdAsync(reportId);
            var stiReport = new StiReport();
            var encoding = Encoding.UTF8;
            var docAsBytes = encoding.GetBytes(report.Content);
            stiReport.Load(docAsBytes);
            foreach (StiDatabase db in stiReport.Dictionary.Databases)
            {
                ((StiSqlDatabase)db).ConnectionString = _configurationManager.ConnectionString;
            }
            foreach (var item in viewModel.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (item.GetValue(viewModel) == null)
                    continue;

                if (item.FieldType == typeof(DateTime?))
                {
                    var value = ((DateTime)item.GetValue(viewModel)).ToString("yyyy-MM-dd");
                    stiReport.Dictionary.Variables.Add(item.Name.GetNameViewModel(), value);
                }
                else
                    stiReport.Dictionary.Variables.Add(item.Name.GetNameViewModel(), item.GetValue(viewModel));
            }
            return stiReport;
        }


        public async Task<DataSourceResult> ListByRequestAsync(DataSourceRequest request)
        {
            var result = _reportRepository.AsNoTracking().ToDataSourceResult(request);

            return new DataSourceResult
            {
                Data = _mapper.Map<List<ReportViewModel>>(result.Data),
                Total = result.Total,
                Aggregates = result.Aggregates
            };
        }


        public async Task<IList<ReportViewModel>> GeAllAsync()
        {
            var request = new ReportSearchRequest();
            var reports = await  GetByRequestAsync(request);
            var dd =  _mapper.Map<List<ReportViewModel>>(reports);
            return dd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<Report>> GetByRequestAsync(ReportSearchRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(ReportSearchRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public IQueryable<Report> QueryByRequest(ReportSearchRequest request)
        {
            var reports = _reportRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById != null)
                reports = reports.Where(model => model.CreatedById == request.CreatedById);

            reports = reports.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Desc}");

            return reports;
        }

        #endregion Public Methods
    }
}