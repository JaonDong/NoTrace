using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TestIdentity.Domain;

namespace TestIdentity.Identity
{
    public class MyUserStore:
          IUserStore<MyUser, long>,
        IUserPasswordStore<MyUser, long>,
        IUserEmailStore<MyUser, long>,
        IUserLockoutStore<MyUser, long>,
        IUserLoginStore<MyUser, long>,
        IQueryableUserStore<MyUser, long>,
        IUserRoleStore<MyUser, long>
    {
        private readonly MyRepository<MyIdentityDbContext,MyUser,long> _useRepository; 


        public MyUserStore(MyRepository<MyIdentityDbContext, MyUser, long> userRepository)
        {
            _useRepository = userRepository;
        }



        public void Dispose()
        {
        }

        public async Task CreateAsync(MyUser user)
        {
             await _useRepository.InsertAsync(user);
        }

        public async Task UpdateAsync(MyUser user)
        {
            await _useRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(MyUser user)
        {
           await _useRepository.DeleteAsync(user);
        }

        public async Task<MyUser> FindByIdAsync(long userId)
        {
            return await _useRepository.FirstOrDefaultAsync(userId);
        }

        public async Task<MyUser> FindByNameAsync(string userName)
        {
            return await _useRepository.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public Task SetPasswordHashAsync(MyUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(MyUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(MyUser user, string email)
        {
            user.EmailAddress = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(MyUser user)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public Task<bool> GetEmailConfirmedAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(MyUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<MyUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(MyUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(MyUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(MyUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(MyUser user)
        {
            throw new NotImplementedException();
        }

        public Task<MyUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MyUser> Users {
            get { return _useRepository.GetAll(); }
        }
        public Task AddToRoleAsync(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(MyUser user)
        {
            var roles = new List<string>();
            roles.Add("test");

            return Task.FromResult((IList<string>)roles);
        }

        public Task<bool> IsInRoleAsync(MyUser user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}