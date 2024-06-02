namespace Features.Users.ApplicationService.Queries;

public record GetUserByPhoneNumberQuery
{
    public GetUserByPhoneNumberQuery()
    {

    }
    public string PhoneNumber { get; set; }
}