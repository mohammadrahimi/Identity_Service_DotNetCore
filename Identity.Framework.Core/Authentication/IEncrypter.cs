 

namespace Identity.Framework.Core.Authentication;

public interface IEncrypter
{
    string GetSalt();
    string GetHash(string value,string salt);

}
