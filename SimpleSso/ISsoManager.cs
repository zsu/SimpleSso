namespace SimpleSso
{
    public interface ISsoManager
    {
        string CreateToken(string loginId, string source);
        int DeleteToken(string token);
        string VerifyToken(string token);
    }
}