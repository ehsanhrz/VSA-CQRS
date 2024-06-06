using Features.Users.ApplicationService.Command;
using Features.Users.ApplicationService.Queries;
using Features.Users.Services;

namespace IntegrationalTests.User;

[Collection("ITests")]
public class UserCudTests
{
    private UserCud UserCud { get; set; }

    private GetUser GetUser { get; set; }

    public UserCudTests(IntegrationalTestsBaseSetUp integrationalTestsBaseSetUp)
    {
        UserCud = new UserCud(integrationalTestsBaseSetUp.DbContext ?? throw new Exception());
        GetUser = new GetUser(integrationalTestsBaseSetUp.DbContext ?? throw new Exception());
    }
    
    [Fact]
    public async Task TestUserCreateMethod()
    {
        //a
        var command = new CreateUserCommand()
        {
            FirstName = "string",
            LastName = "string",
            Email = "string",
            PhoneNumber = "string"
        };
        var query = new GetUserByEmailQuery(command.Email);
       
        
        //a
        await UserCud.CreateAsync(command);
        var result = await GetUser.GetUserByEmailAsync(query.Email);
        
        //a checking two must unique value
        Assert.Equal(result.Email,command.Email);
        Assert.Equal(result.PhoneNumber, command.PhoneNumber);
    }
    
    [Fact]
    public async Task TestUpdateUserMethod()
    {
        //a
        var createCommand = new CreateUserCommand()
        {
            FirstName = "string2",
            LastName = "string2",
            Email = "string2",
            PhoneNumber = "string2"
        };
        var query = new GetUserByEmailQuery(createCommand.Email);
        
        
        await UserCud.CreateAsync(createCommand);
        var createOperationResult = await GetUser.GetUserByEmailAsync(query.Email);
        
        //a
        const string newEmail = "string23";
        const string newPhone = "string23";

        var updateCommand = new UpdateUserCommand()
        {
            Email = newEmail,
            FirstName = createOperationResult.FirstName,
            PhoneNumber = newPhone,
            LastName = createOperationResult.LastName,
            Id = createOperationResult.Id
        };
        var updateResultQuery = new GetUserByEmailQuery(newEmail);
        
        await UserCud.UpdateAsync(updateCommand);
        var updateOperationResult = await GetUser.GetUserByEmailAsync(updateResultQuery.Email);
        
        //a
        Assert.Multiple(() =>
        {
            Assert.Equal(updateCommand.Email, updateOperationResult.Email);
            Assert.Equal(updateCommand.PhoneNumber, updateOperationResult.PhoneNumber);
        });
    }
    
    [Fact]
    public async Task TestDeleteUserMethode()
    {
        //a
        var command = new CreateUserCommand()
        {
            FirstName = "string4",
            LastName = "string4",
            Email = "string4",
            PhoneNumber = "string4"
        };
        
        var query = new GetUserByEmailQuery(command.Email);
        
        
        await UserCud.CreateAsync(command);
        var result = await GetUser.GetUserByEmailAsync(query.Email);

        //a
        var deleteCommand = new DeleteUserCommand()
        {
            Id = result.Id
        };
        await UserCud.DeleteAsync(deleteCommand);

        //a
        Assert.Throws<AggregateException>(() => GetUser.GetUserByEmailAsync(query.Email).Wait());
    }
}