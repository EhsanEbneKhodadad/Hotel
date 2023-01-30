using Hotel.Models;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO userDTO);
        Task<string> CreateToken();
    }
}
