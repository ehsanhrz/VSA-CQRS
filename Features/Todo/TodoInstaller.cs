using Features.Todo.Providers;
using Features.Todo.Services;
using Features.Users.Services;

namespace Features.Todo
{
    public static class TodoInstaller
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TodoCud>();
            serviceCollection.AddScoped<UserProvider>();
        }
    }
}
