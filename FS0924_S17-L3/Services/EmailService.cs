using FluentEmail.Core;
using FS0924_S17_L3.ViewModels;

namespace FS0924_S17_L3.Services
{
    public class EmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task<bool> SendEmail(string userName, string bookTitle)
        {
            try
            {
                var emailViewModel = new EmailViewModel()
                {
                    UserName = userName,
                    BookTitle = bookTitle,
                };

                var res = await _fluentEmail
                    .To("ExcerciseEfc@ExcerciseEfc.com")
                    .Subject("New product")
                    .UsingTemplateFromFile("Views/Templates/EmailTemplate.cshtml", emailViewModel)
                    .SendAsync();

                return res.Successful;
            }
            catch
            {
                return false;
            }
        }
    }
}
