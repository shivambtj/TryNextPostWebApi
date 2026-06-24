namespace TryNextPostWebApi.IServices
{
    public interface INotificationService
    {
        Task<Tuple<int, string>> SendAsync(string email, string userName);
    }
}
