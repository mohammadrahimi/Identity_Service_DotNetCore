﻿

using System.Security.Cryptography;

namespace Identity.Framework.Core.Authentication;

public sealed class Encrypter : IEncrypter
{
    private static readonly int SaltSize = 40;
    private static readonly int DeriveBytesIterationsCount = 10000;

    public string GetSalt()
    {
        var saltBytes = new byte[SaltSize];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    public string GetHash(string value, string salt)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);
        return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
    }
    private static byte[] GetBytes(string value)
    {
        var bytes = new byte[value.Length * sizeof(char)];
        Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }

}
