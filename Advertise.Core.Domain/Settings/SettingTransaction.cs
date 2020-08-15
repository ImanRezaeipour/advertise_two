using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Settings
{
   public class SettingTransaction:BaseEntity
    {
        public virtual string NameOfAccountNumber { get; set; }
        public virtual string CorporationShebaNumber { get; set; }
        public virtual string CorporationShetabNumber { get; set; }
        public virtual string CorporationAccountNumber { get; set; }
        public virtual string BankName { get; set; }

    }
}
