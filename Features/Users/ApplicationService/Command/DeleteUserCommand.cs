namespace Features.Users.ApplicationService.Command;

public record DeleteUserCommand
{
    public DeleteUserCommand()
    {

    }

    public long Id { get; set; }
};