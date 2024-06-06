using Features.Users.Models.DTOs;
using Features.Users.Services;

namespace Features.Todo.Providers
{
    public class UserProvider 
    {
        private readonly GetUser getUser;

        public UserProvider(GetUser getUser)
        {
            this.getUser = getUser;
        }

        public async Task<UserDto> GetUserById(long userId)
        {
            return await getUser.GetUserByIdAsync(userId);
        }
    }
}
