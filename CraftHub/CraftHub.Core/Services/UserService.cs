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

        public async Task<int> CreateProductCategoryAsync(string productCategory)
        {
            ProductCategory productCat = new ProductCategory()
            {
                Name= productCategory,
            };

            await repository.AddAsync(productCat);
            await repository.SaveChangesAsync();

            return productCat.Id;
        }

        public async Task<bool> ProductCategoryExistsAsync(string productCategory)
        {
            return await repository.AllReadOnly<ProductCategory>()
                   .AnyAsync(x => x.Name==productCategory);
        }

        public async Task<int> CreateCourseCategoryAsync(string courseCategory)
        {
            CourseCategory courseCat = new CourseCategory()
            {
                Name = courseCategory,
            };

            await repository.AddAsync(courseCat);
            await repository.SaveChangesAsync();

            return courseCat.Id;
        }

        public async Task<bool> CourseCategoryExistsAsync(string courseCategory)
        {
            return await repository.AllReadOnly<CourseCategory>()
                   .AnyAsync(x => x.Name == courseCategory);
        }
    }
}
