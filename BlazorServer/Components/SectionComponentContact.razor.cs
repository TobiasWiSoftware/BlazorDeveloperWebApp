using SendGrid.Helpers.Mail;
using SendGrid;
using SharedLibrary.Dtos;

namespace BlazorServer.Components
{
    public partial class SectionComponentContact
    {
        public EmailDto EmailDto { get; set; } = new();

        public async Task TaskSendEmail()
        {
            try
            {
                //var Client = new SendGridClient("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");
                //var to = new EmailAddress("tobiaswisoftware@gmail.com");
                //var from = new EmailAddress(EmailDto.Email, EmailDto.Name);
                //var msg = MailHelper.CreateSingleEmail(from, to, EmailDto.Subject, EmailDto.Message, EmailDto.Message);
                //var response = await Client.SendEmailAsync(msg);

                //var apiKey = Environment.GetEnvironmentVariable("nSG.HuWqOKwHT2OMuJsd75nqMQ.w7rlwNQzIB-F1hWOoWx17ozZ1Q9GAgH74IZmdvPrl30");
                var client = new SendGridClient("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");
                var from = new EmailAddress("tobiaswisoftware@gmail.com", "Example User");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("tobiaswisoftware@gmail.com", "Example User");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                Console.WriteLine(response.StatusCode);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }


        }
    }
}
