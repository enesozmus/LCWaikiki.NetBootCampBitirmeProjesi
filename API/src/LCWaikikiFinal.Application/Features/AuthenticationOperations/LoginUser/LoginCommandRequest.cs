using LCWaikikiFinal.Application.Response;
using MediatR;

namespace LCWaikikiFinal.Application.Features.AuthenticationOperations
{
        public class LoginCommandRequest : IRequest<LoginCommandResponse>
        {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
