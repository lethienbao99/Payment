using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Features.Merchants.Commands;

namespace Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public ActionResult Create(CreateMerchant request)
        {
            return Ok(_mediator.Send(request));
        }
    }
}
