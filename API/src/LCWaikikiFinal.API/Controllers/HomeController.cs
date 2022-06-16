using LCWaikikiFinal.Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class HomeController : ControllerBase
        {
                private readonly IMediator _mediator;

                public HomeController(IMediator mediator)
                {
                        _mediator = mediator;
                }

                #region Kategori ve Ürünlerini Getir

                [HttpGet("{id}")]
                public async Task<IActionResult> ProductsByCategory(int? id) => Ok(await _mediator.Send(new GetProductsByCategoryQueryRequest(id)));

                #endregion
        }
}
