namespace SAWBank.BLL.Interfaces
{
    public interface IPasswordHasher
    {
        byte[] Hash(string password);
    }
}
