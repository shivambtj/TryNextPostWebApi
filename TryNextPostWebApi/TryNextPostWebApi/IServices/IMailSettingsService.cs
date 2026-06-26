using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IMailSettingsService
    {
        Task<Tuple<int, string>> SaveMailData(MailSettingsDto mailSettingsDto);
        Task<Tuple<int, string>> UpdateMailData(MailSettingsDto mailSettingsDto);
        Task<Tuple<int, MailSettingsDto>> GetDataById(long id);
        Task<Tuple<int, List<MailSettingsDto>>> getAllData();
        Task<Tuple<int, String>> removeDataById(long id);

    }
}
