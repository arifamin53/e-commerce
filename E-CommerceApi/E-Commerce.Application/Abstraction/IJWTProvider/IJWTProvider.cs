using E_commerce.Domain.Entities;
namespace E_Commerce.Application.Abstraction.IJWTProvider
{
    public interface IJWTProvider
    {
        string GenerateAuthToken(User user);
    }
}
