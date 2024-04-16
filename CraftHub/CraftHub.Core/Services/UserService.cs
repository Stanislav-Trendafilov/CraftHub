using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Admin.User;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Core.Services
{
    public class UserService :IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
           var allCreators=await repository.AllReadOnly<Creator>()
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    IsCreator = true
                })
                .ToListAsync();

            var allUsers= await repository.AllReadOnly<IdentityUser>()
               .Select(u => new UserServiceModel()
               {
                   Email = u.Email,
                   IsCreator =  false
               })
               .ToListAsync();

            List<UserServiceModel>   allAsync= new List<UserServiceModel>();

            foreach (var user in allCreators)
            {
                allAsync.Add(user);
            }

            foreach (var item in allUsers)
            {
                 if(!allCreators.Any(u=>allCreators.Select(c=>c.Email).Contains(item.Email)==true))
                {
                    allAsync.Add(item);
                }
            }
            return allAsync;
        }

    }
}
