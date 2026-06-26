namespace TryNextPostWebApi.IServices
{
    public interface INotificationService
    {
        Task<Tuple<int, string>> SendAsync(string email, string userName);
        Task<Tuple<int, string>> SendOTPForMail(string email,string OTP,string username);
    }
}
