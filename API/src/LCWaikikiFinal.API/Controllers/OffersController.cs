using LCWaikikiFinal.Application.Features.OfferOperations.Command;
using LCWaikikiFinal.Application.Features.OfferOperations.Queries;
using LCWaikikiFinal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using LCWaikikiFinal.Application.Features.OfferOperations.Command.AcceptOffer;

namespace LCWaikikiFinal.API.Controllers
{
        [EnableCors]
        [Route("api/[controller]")]
        [ApiController]
        public class OffersController : ControllerBase
        {
                private readonly IMediator _mediator;
                private readonly UserManager<AppUser> _userManager;

                public OffersController(IMediator mediator, UserManager<AppUser> userManager)
                {
                        _mediator = mediator;
                        _userManager = userManager;
                }

                #region Kullanıcıya Ait Teklifleri Getir

                [Authorize(AuthenticationSchemes = "Bearer")]
                [HttpGet("{id}")]
                public async Task<IActionResult> GetOffersByUser(int id)
                {
                        var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
                        id = userId;

                        return Ok(await _mediator.Send(new GetOffersByUserQueryRequest(userId)));
                }
                #endregion

                #region Kullanıcının Verdiği Teklifleri Geri Çek

                [HttpDelete("{Id}")]
                public async Task<IActionResult> RemoveOffer([FromRoute] RemoveOfferCommandRequest deleteOfferCommandRequest) => Ok(await _mediator.Send(deleteOfferCommandRequest));

                #endregion

                #region Teklif Yap Opsiyonu

                [Authorize(AuthenticationSchemes = "Bearer")]
                [HttpPost]
                public async Task<IActionResult> CreateOffer(CreateOfferCommandRequest createOfferCommandRequest)
                {
                        var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
                        createOfferCommandRequest.AppUserId = userId;

                        return Ok(await _mediator.Send(createOfferCommandRequest));
                }
                #endregion

                #region Teklifi Onayla Opsiyonu

                [HttpPut]
                public async Task<IActionResult> AcceptOffer(AcceptOfferCommandRequest request) => Ok(await _mediator.Send(request));
                        
                #endregion
        }
}
