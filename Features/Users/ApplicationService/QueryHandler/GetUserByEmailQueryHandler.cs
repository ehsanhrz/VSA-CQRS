using Features.Users.ApplicationService.Queries;
using Features.Users.Models.DTOs;
using Features.Users.Services;
using MediatR;

namespace Features.Users.ApplicationService.QueryHandler
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly GetUser getUser;

        public GetUserByEmailQueryHandler(GetUser getUser)
        {
            this.getUser = getUser;
        }
        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await getUser.GetUserByEmailAsync(request);
        }
    }
}
