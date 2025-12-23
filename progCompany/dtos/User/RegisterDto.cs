using progCompany.Models.UserModel;

namespace progCompany.dtos.User
{
    public class RegisterDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; } // Client / Developer / Admin
    }

}
