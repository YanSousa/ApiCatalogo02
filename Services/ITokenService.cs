using ApiCatalogo02.Models;

namespace ApiCatalogo02.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, string audience, UserModel user);



    }
}
