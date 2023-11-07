using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListApiWithAuth.Models.Response
{
    public class GetUsersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}