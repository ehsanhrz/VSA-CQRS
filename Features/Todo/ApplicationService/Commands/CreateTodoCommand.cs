using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Features.Todo.ApplicationService.Commands
{
    public record CreateTodoCommand : IRequest
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

    }
}
