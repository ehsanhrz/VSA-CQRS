using Features.Users.Models.DTOs;
using MediatR;

namespace Features.Users.ApplicationService.Queries;

public record GetUserByEmailQuery : IRequest<UserDto>
{
    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
    public string Email { get; set; }
}