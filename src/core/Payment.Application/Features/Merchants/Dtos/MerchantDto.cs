﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Merchants.Dtos
{
    public class MerchantDto
    {
        public string? MerchantName { get; set; }

        public string? MerchantWebLink { get; set; }

        public string? MerchantIpnUrl { get; set; }

        public string? MerchantReturnUrl { get; set; }

        public string? SerectKey { get; set; }

        public bool? IsActive { get; set; }
    }
}
