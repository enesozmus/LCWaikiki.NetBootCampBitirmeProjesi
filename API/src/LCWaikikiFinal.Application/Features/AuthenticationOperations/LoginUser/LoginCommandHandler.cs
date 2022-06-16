using AutoMapper;
using LCWaikikiFinal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LCWaikikiFinal.Application.Features.AuthenticationOperations
{
        public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse> 
        {
                private readonly UserManager<AppUser> _userManager;
                private readonly IMapper _mapper;

                public LoginCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
                {
                        _mapper = mapper;
                        _userManager = userManager;
                }

                public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
                {
                        LoginCommandResponse response = new();
                        var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);
                        if (user is null)
                                throw new NotFoundUserException("Kullanıcı veya şifre hatalı!");

                        var userModel = _mapper.Map<LoginCommandResponse>(user);
                        var userSigninResult = await _userManager.CheckPasswordAsync(user, request.Password);

                        if (userSigninResult)
                        {
                                response.IsSuccess = true;
                                response.Id = userModel.Id;
                                response.FirstName = userModel.FirstName;
                                response.LastName = userModel.LastName;
                                response.UserName = userModel.UserName;
                                response.Email = userModel.Email;
                                return response;
                        }

                        return new();
                }
        }
}
