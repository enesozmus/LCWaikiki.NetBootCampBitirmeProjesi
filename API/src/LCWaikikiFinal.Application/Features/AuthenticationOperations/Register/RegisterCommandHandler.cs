using AutoMapper;
using LCWaikikiFinal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LCWaikikiFinal.Application.Features.AuthenticationOperations
{
        public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
        {
                private readonly UserManager<AppUser> _userManager;
                private readonly IMapper _mapper;

                public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
                {
                        _userManager = userManager;
                        _mapper = mapper;
                }

                public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
                {
                        var userEntity = _mapper.Map<AppUser>(request);
                        var result = await _userManager.CreateAsync(userEntity, request.Password);

                        RegisterCommandResponse response = new() { IsSuccess = result.Succeeded };

                        if (result.Succeeded)
                        {
                                response.IsSuccess = true;
                                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
                                return response;
                        }
                        else
                        {
                                foreach (var error in result.Errors)
                                        response.Message += $"{error.Description}\n";
                                return response;
                        }
                }
        }
}
