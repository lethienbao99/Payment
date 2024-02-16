using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Merchant.Commands
{
    public class ActiveMerchant
    {
        public string Id { get; set; } = null!;
        public bool? IsActive { get; set; }

    }
}
