namespace alimenta.bem.helpers;

public class FormatPassword
{
    public static string GenerateHash(string password)
    {
        var pwdSalt = BCrypt.Net.BCrypt.GenerateSalt(8);

        return BCrypt.Net.BCrypt.HashPassword(password, pwdSalt);
    }

    public static bool ComparePassword(string password, string hashToCompare)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashToCompare);
    }
}