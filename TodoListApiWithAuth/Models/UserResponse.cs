namespace TodoListApiWithAuth.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswrodSalt { get; set; }
    }
}