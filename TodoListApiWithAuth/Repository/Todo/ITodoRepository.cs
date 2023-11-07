using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using TodoListApiWithAuth.Models;

namespace TodoListApiWithAuth.Repository.Todo
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Add(TodoItem item);
        void Update(int id, TodoItem item);
        void Delete(int id);
    }
}