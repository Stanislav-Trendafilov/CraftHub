using CraftHub.Core.Models.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Contracts
{
    public interface ICreatorService
    {
        Task<bool> ExistByIdAsync(string userId);

		Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

		Task CreateAsync(string userId,BecomeCreatorFormModel model);

		Task <int?> GetCreatorIdAsync(string userId);
	}
}
