using AutoMapper;
using LCWaikikiFinal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LCWaikikiFinal.Application.Features.AuthenticationOperations
{
        public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQueryRequest, GetUserDetailQueryResponse>
        {
                private readonly UserManager<AppUser> _userManager;
                private readonly IMapper _mapper;

                public GetUserDetailQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
                {
                        _userManager = userManager;
                        _mapper = mapper;
                }

                public async  Task<GetUserDetailQueryResponse> Handle(GetUserDetailQueryRequest request, CancellationToken cancellationToken)
                {
                        var user = _userManager.Users.SingleOrDefault(x => x.Id == request.Id);
                        return _mapper.Map<GetUserDetailQueryResponse>(user);
                }
        }
}
