using Features.Users.ApplicationService.Command;
using Features.Users.ApplicationService.Queries;
using Features.Users.Models.DTOs;
using Features.Users.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Features.Users.Controllers;

[ApiController]
[Route("[Controller]/[Action]")]
public class UsersController : ControllerBase
{
    private readonly ISender sender;

    public UsersController(ISender sender)
    {
        this.sender = sender;
    }
    
    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        await sender.Send(command);
        return Ok();
    }

    [HttpGet(Name = "GetUserByEmail")]
    public async Task<ActionResult<UserDto>> GetUserByEmail([FromQuery] GetUserByEmailQuery query)
    {
        var result = await sender.Send(query);
        return Ok(result);
    }
}