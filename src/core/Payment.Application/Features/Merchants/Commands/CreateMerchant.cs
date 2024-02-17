using Mapster;
using MediatR;
using Payment.Application.Features.Merchants.Dtos;
using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Features.Merchants.Commands
{
    public class CreateMerchant : IRequest<MerchantDto>
    {
        public string? MerchantName { get; set; }

        public string? MerchantWebLink { get; set; }

        public string? MerchantIpnUrl { get; set; }

        public string? MerchantReturnUrl { get; set; }
    }

    public class CreateMerchantHandler : IRequestHandler<CreateMerchant, MerchantDto>
    {
        private readonly PaymentContext _paymentContext;
        public CreateMerchantHandler(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }
        public Task<MerchantDto> Handle(CreateMerchant request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Merchant();
                entity = request.Adapt<Merchant>();
                _paymentContext.Merchants.Add(entity);
                _paymentContext.SaveChanges();
                return Task.FromResult(entity.Adapt<MerchantDto>());
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

}
