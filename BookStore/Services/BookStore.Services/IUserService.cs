using BookStore.Common.Entities;

namespace BookStore.Services
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}