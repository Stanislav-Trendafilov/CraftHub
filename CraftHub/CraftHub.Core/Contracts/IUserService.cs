using CraftHub.Core.Models.Admin.User;

namespace CraftHub.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> AllAsync();
    }
}
