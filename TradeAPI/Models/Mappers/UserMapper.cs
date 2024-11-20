using TradeAPI.Models.DTO;

namespace TradeAPI.Models.Mappers
{
    public class UserMapper
    {
        public static UserDTO ConvertToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Surname = user.Surname,
                Name = user.Name,
                Patronymic = user.Patronymic,
                Password = user.Password,
                Login = user.Login,
                Role = user.Role
            };
        }
        public static User ConvertToModel(UserDTO user)
        {
            return new User
            {
                UserId = user.UserId,
                Surname = user.Surname,
                Name = user.Name,
                Patronymic = user.Patronymic,
                Password = user.Password,
                Login = user.Login,
                Role = user.Role
            };
        }
    }
}
