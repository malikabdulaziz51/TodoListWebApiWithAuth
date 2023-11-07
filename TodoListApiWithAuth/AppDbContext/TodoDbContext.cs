using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoListApiWithAuth.Models;

namespace TodoListApiWithAuth.AppDbContext
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<UserResponse> Users { get; set; }
    }
}