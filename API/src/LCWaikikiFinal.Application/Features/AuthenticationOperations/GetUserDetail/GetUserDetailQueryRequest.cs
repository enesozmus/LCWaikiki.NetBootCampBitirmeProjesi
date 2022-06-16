using MediatR;

namespace LCWaikikiFinal.Application.Features.AuthenticationOperations
{
        public class GetUserDetailQueryRequest : IRequest<GetUserDetailQueryResponse>
        {
                public GetUserDetailQueryRequest(int id)
                {
                        Id = id;
                }

                public int Id { get; set; }
        }
}
