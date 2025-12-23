using progCompany.Models.UserModel;

namespace progCompany.Models.ClientProfile
{
    public class ClientProfile   {
        public int UserId { get; set; }
        public string CompanyName { get; set; }

        public string Phone {  get; set; }

        public string Address { get; set; }
        public UserClass User { get; set; }
    }
}
