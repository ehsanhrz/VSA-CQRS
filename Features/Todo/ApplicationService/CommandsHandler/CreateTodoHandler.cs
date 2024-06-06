using DbContext.Entities.Todo;
using Features.Todo.ApplicationService.Commands;
using Features.Todo.Providers;
using Features.Todo.Services;
using MediatR;

namespace Features.Todo.ApplicationService.CommandsHandler
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand>
    {
        private readonly TodoCud todoCud;
        private readonly UserProvider userProvider;

        public CreateTodoHandler(TodoCud todoCud, UserProvider userProvider)
        {
            this.todoCud = todoCud;
            this.userProvider = userProvider;
        }
        public async Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var user = userProvider.GetUserById(request.UserId);
            var newTodo = new DbContext.Entities.Todo.Todo(request.Title, request.Description, request.UserId);
            await todoCud.CreateTodoWithUser(newTodo);
        }
    }
}
