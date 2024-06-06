using DbContext;
using DbContext.Entities.Users;

namespace Features.Todo.Services
{
    public class TodoCud
    {
        private readonly AppDbContext dbContext;

        public TodoCud(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateTodoWithUser(DbContext.Entities.Todo.Todo todo)
        {

            await dbContext.AddAsync(todo);
            await dbContext.SaveChangesAsync();
        }
    }
}
