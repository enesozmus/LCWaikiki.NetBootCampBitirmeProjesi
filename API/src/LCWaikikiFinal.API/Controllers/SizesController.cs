using LCWaikikiFinal.Application.Features.SizeOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class SizesController : ControllerBase
        {
                private readonly IMediator _mediator;

                public SizesController(IMediator mediator) { _mediator = mediator; }

                #region Bedenleri Getir

                [HttpGet]
                public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetSizesQueryRequest()));

                #endregion
        }
}
