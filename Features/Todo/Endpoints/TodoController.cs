using Features.Todo.ApplicationService.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Features.Todo.Endpoints
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class TodoController : ControllerBase
    {
        private readonly ISender sender;

        public TodoController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost(Name = "CreateTodo")]
        public async Task<ActionResult> CreateTodoWithUser([FromBody] CreateTodoCommand command)
        {
            await sender.Send(command);
            return Ok();
        }
    }
}
