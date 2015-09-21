using System.Security.AccessControl;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NoTrace.Core.Users;

namespace NoTrace.Application.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        /// <summary>
        ///     姓
        /// </summary>
        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }
}