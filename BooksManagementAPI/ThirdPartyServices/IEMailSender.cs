namespace BooksManagementAPI.ThirdPartyServices
{
    public interface IEMailSender
    {
        Task SendMail(string from, string subject, string to, string body);
    }
}
