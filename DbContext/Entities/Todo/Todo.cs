using DbContext.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext.Entities.Todo
{
    public class Todo
    {
        public Todo()
        {
            
        }
        public Todo(string title, string description, long userId)
        {
            Title = title; 
            Description = description; 
            UserId = userId;
        }
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long UserId { get; set; }
    }
}
