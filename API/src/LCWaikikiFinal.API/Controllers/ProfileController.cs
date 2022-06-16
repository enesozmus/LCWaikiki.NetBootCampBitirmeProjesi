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
        public class ProfileController : ControllerBase
        {
                private readonly IMediator _mediator;
                private readonly UserManager<AppUser> _userManager;

                public ProfileController(IMediator mediator, UserManager<AppUser> userManager)
                {
                        _mediator = mediator;
                        _userManager = userManager;
                }

                #region Kullanıcıya Ait Ürünleri Getir

                [Authorize(AuthenticationSchemes = "Bearer")]
                [HttpGet("{id}")]
                public async Task<IActionResult> GetProductsByUser(int id)
                {
                        var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
                        id = userId;

                        return Ok(await _mediator.Send(new GetProductsByUserQueryRequest(userId)));
                }
                #endregion
        }
}
