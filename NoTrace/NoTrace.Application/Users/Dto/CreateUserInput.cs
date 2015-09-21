using Abp.Application.Services.Dto;

namespace NoTrace.Application.Users.Dto
{
    public class CreateUserInput : EntityRequestInput<long>
    {
        public string UserName { get; set; }
        public string SurnName { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}