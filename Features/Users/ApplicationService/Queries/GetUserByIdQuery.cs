namespace Features.Users.ApplicationService.Queries;

public record GetUserByIdQuery
{
    public GetUserByIdQuery()
    {

    }

    public long UserId { get; set; }
}