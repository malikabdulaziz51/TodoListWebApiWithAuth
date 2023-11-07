using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TodoListApiWithAuth.AppDbContext;
using TodoListApiWithAuth.Custom.Error;
using TodoListApiWithAuth.Models;
using TodoListApiWithAuth.Repository.Todo;

namespace TodoListApiWithAuth.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController()
        {
            _todoRepository = new TodoRepository();
        }

        [HttpGet, AllowAnonymous]
        [Route("api/todo/search")]
        public IHttpActionResult Search(string keyword) 
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Ok(_todoRepository.GetAll());
            }

            var result = _todoRepository
                        .GetAll()
                        .Where(i => i.Title.Contains(keyword) || i.Description.Contains(keyword))
                        .ToList();

            if(result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet, AllowAnonymous]
        [Route("api/todo")]
        public IHttpActionResult Get(int page = 1)
        {
            int pageSize = 5;
            var totalItem = _todoRepository.GetAll().Count();
            var totalPages = Math.Ceiling((double)totalItem / pageSize);

            var items = _todoRepository.GetAll()
                        .OrderBy(i => i.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            var result = new
            {
                TotalItem = totalItem,
                TotalPages = totalPages,
                Items = items
            };
            return Ok(result);
        }

        [HttpGet]
        [Route("api/todo/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var item = _todoRepository.GetById(id);
            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost, AuthorizationErrorMessage]
        
        [Route("api/todo")]
        public void Post(TodoItem item)
        {
            _todoRepository.Add(item);
        }

        [HttpPut, AuthorizationErrorMessage]
        [Route("api/todo/{id}")]
        public void Put(int id, TodoItem item)
        {
            _todoRepository.Update(id, item);
        }

        [HttpDelete, AuthorizationErrorMessage]
        [Route("api/todo/{id}")]
        public void Delete(int id)
        {
            _todoRepository.Delete(id);
        }
    }
}
