using LCWaikikiFinal.Application.Features.ProductOperations.Command;
using LCWaikikiFinal.Application.Features.ProductOperations.Queries;
using LCWaikikiFinal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
                private readonly IMediator _mediator;
                private readonly UserManager<AppUser> _userManager;

                public ProductsController(IMediator mediator, UserManager<AppUser> userManager)
                {
                        _mediator = mediator; _userManager = userManager;
                }

                #region Bütün Ürünleri Getir

                [HttpGet]
                public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetProductsQueryRequest()));

                #endregion

                #region Ürün Detaylarını Getir

                [HttpGet("{id}")]
                public async Task<IActionResult> GetDetail(int id) => Ok(await _mediator.Send(new GetProductDetailQueryRequest(id)));

                #endregion

                #region Kullanıcı Tarafından Ürün Ekle

                [Authorize(AuthenticationSchemes = "Bearer")]
                [HttpPost]
                public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductQueryRequest)
                {
                        var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
                        createProductQueryRequest.AppUserId = userId;
                        createProductQueryRequest.IsSold = false;

                        return Ok(await _mediator.Send(createProductQueryRequest));
                }
                #endregion

                #region Kullanıcı Tarafından Ürün Sil

                [HttpDelete("{Id}")]
                public async Task<IActionResult> RemoveProduct([FromRoute] RemoveProductCommandRequest removeProductCommandRequest) => Ok(await _mediator.Send(removeProductCommandRequest));

                #endregion
        }
}
