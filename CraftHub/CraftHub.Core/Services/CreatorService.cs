using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Creator;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftHub.Core.Services
{
    public class CreatorService :ICreatorService
    {
        private readonly IRepository repository;

        public CreatorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Creator>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task CreateAsync(string userId, BecomeCreatorFormModel model)
        {
            await repository.AddAsync(new Creator()
            {
                UserId = userId,
                PhoneNumber = model.PhoneNumber,
                FullName= model.FullName,
                BusinessName=model.BusinessName,
                MoreInformation=model.MoreInformation,
                Email=model.Email,
                Website=model.Website,

			});

            await repository.SaveChangesAsync();
        }

		public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
		{
			return await repository.AllReadOnly<Creator>()
				 .AnyAsync(h => h.PhoneNumber == phoneNumber);
		}

		public async Task<int?> GetCreatorIdAsync(string userId)
		{
			return (await repository.AllReadOnly<Creator>()
				.FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
		}


	}
}
