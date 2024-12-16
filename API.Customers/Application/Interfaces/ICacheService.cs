namespace API.Customers.Application.Interfaces
{
    public interface ICacheService
    {
        void Set<T>(string key, T value, TimeSpan expiration);
        T? Get<T>(string key);
    }
}
