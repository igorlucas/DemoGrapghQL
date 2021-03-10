using Domain.Entities;

namespace Web.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Phone = user.Phone;
            this.Email = user.Email;
        }
    }
}
