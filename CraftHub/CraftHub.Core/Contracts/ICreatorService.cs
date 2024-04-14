using CraftHub.Core.Models.Creator;

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
