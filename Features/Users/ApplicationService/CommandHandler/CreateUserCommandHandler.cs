using Features.Users.ApplicationService.Command;
using Features.Users.Services;
using MediatR;

namespace Features.Users.ApplicationService.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserCud userCud;

        public CreateUserCommandHandler(UserCud userCud)
        {
            this.userCud = userCud;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await userCud.CreateAsync(request);
        }
    }
}
