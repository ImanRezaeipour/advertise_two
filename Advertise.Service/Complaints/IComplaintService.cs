using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Complaints;
using Advertise.Core.Models.Complaint;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Complaints
{
    public interface IComplaintService {
        Task  CreateByViewModel(ComplaintCreateViewModel viewModel);
        Task  DeleteByIdAsync(Guid complaintId);
        Task<Complaint> FindByIdAsync(Guid complaintId);
        Task<IList<Complaint>> GetByRequestAsync(ComplaintSearchRequest request);
        Task<int> CountByRequestAsync(ComplaintSearchRequest request);


       IQueryable<Complaint> QueryByRequest(ComplaintSearchRequest request);
    }
}