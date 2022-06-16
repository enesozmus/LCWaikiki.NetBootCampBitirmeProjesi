using LCWaikikiFinal.Application.Features.LifecyclesOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class LifecyclesController : ControllerBase
        {
                private readonly IMediator _mediator;

                public LifecyclesController(IMediator mediator) { _mediator = mediator; }

                #region Kullanım Durumlarını/Ömürlerini Getir

                [HttpGet]
                public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetLifecyclesQueryRequest()));

                #endregion
        }
}
