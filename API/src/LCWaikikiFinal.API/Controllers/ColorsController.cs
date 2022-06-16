using LCWaikikiFinal.Application.Features.ColorOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class ColorsController : ControllerBase
        {
                private readonly IMediator _mediator;

                public ColorsController(IMediator mediator) { _mediator = mediator; }

                #region Renkleri Getir

                [HttpGet]
                public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetColorsQueryRequest()));

                #endregion
        }
}
