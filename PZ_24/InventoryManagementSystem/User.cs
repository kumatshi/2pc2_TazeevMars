using System;

namespace InventoryManagementSystem
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        
    }

}
