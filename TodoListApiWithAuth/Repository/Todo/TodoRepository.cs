using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using TodoListApiWithAuth.AppDbContext;
using TodoListApiWithAuth.Models;

namespace TodoListApiWithAuth.Repository.Todo
{
    public class TodoRepository : ITodoRepository
    {
        private TodoDbContext todoDbContext = new TodoDbContext();
        public void Add(TodoItem item)
        {
            todoDbContext.TodoItems.Add(item);
            todoDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);
            if(todo !=null)
            {
                todoDbContext.TodoItems.Remove(todo);
                todoDbContext.SaveChanges();
            }
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return todoDbContext.TodoItems.ToList();
        }

        public TodoItem GetById(int id)
        {
            return todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, TodoItem item)
        {
            var todo = todoDbContext.TodoItems.FirstOrDefault(t => t.Id == id);
            if(todo != null)
            {
                todo.Title = item.Title;
                todo.Description = item.Description;
                todo.IsDone = item.IsDone;
                todoDbContext.SaveChanges();
            }
        }

    }
}