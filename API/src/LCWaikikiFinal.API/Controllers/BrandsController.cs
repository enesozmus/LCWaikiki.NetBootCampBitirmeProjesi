using LCWaikikiFinal.Application.Features.BrandOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class BrandsController : ControllerBase
        {
                private readonly IMediator _mediator;

                public BrandsController(IMediator mediator) { _mediator = mediator; }

                #region Markaları Getir

                [HttpGet]
                public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetBrandsQueryRequest()));

                #endregion
        }
}
