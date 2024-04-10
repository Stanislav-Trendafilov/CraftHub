using CraftHub.Core.Contracts;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Creator()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

		public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
		{
			return await repository.AllReadOnly<Creator>()
				 .AnyAsync(h => h.PhoneNumber == phoneNumber);
		}
	}
}
