using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using NoTrace.Application.Users.Dto;
using NoTrace.Core.Users;

namespace NoTrace.Application.Users
{
    public class UserAppService:IUserAppService
    {
        #region Fields
        private readonly UserManager _userManager;
        private readonly IRepository<User,long> _useRepository;
        #endregion

        #region Constructor
        public UserAppService(UserManager userManager,IRepository<User,long> useRepository )
        {
            _userManager = userManager;
            _useRepository = useRepository;
        } 
        #endregion

        public ListResultOutput<UserDto> GetUsers()
        {
            return new ListResultOutput<UserDto>
            {
                Items = _userManager.Users.ToList().MapTo<List<UserDto>>()
            };
        }

        public async Task CreateUser(CreateUserInput input)
        {
            var user = input.MapTo<User>();
            await _useRepository.InsertAsync(user);
        }
    }
}