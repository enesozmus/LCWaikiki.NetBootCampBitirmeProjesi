using LCWaikikiFinal.Application.Features.AuthenticationOperations;
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
        public class AuthenticationController : ControllerBase
        {
                private readonly IMediator _mediator;
                private readonly UserManager<AppUser> _userManager;

                public AuthenticationController(IMediator mediator, UserManager<AppUser> userManager)
                {
                        _mediator = mediator;
                        _userManager = userManager;
                }

                #region Kayıt Ol

                [HttpPost("Register")]
                public async Task<IActionResult> Register(RegisterCommandRequest request) => Ok(await _mediator.Send(request));

                #endregion

                #region Giriş Yap

                [HttpPost("Login")]
                public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
                {
                        LoginCommandResponse response = await _mediator.Send(loginCommandRequest);
                        //var query = new LoginCommandRequest(email, password);
                        //LoginCommandResponse response = await _mediator.Send(query);
                        if (response.IsSuccess)
                        {
                                response.Token = JwtTokenGenerator.GenerateToken(response);
                                return Ok(response);
                        }
                        return BadRequest("Kullanıcı adı veya parola hatalı!");
                }
                #endregion


                #region Kullanıcı Detaylarını Getir
                [Authorize(AuthenticationSchemes = "Bearer")]
                [HttpGet("{id}")]
                public async Task<IActionResult> GetDetail(int id)
                {
                        var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
                        id = userId;

                        return Ok(await _mediator.Send(new GetUserDetailQueryRequest(id)));
                }
                #endregion
        }
}
