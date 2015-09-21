using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using NoTrace.Application.Users.Dto;

namespace NoTrace.Application.Users
{
    public interface IUserAppService
    {
        ListResultOutput<UserDto> GetUsers();
        Task CreateUser(CreateUserInput input);
    }
}