using SendGrid.Helpers.Mail;
using SendGrid;
using SharedLibrary.Dtos;

namespace BlazorServer.Components
{
    public partial class SectionComponentContact
    {
        public EmailDto Email { get; set; } = new();

        public async Task TaskSendEmail()
        {
            try
            {

                //var apiKey = Environment.GetEnvironmentVariable("nSG.HuWqOKwHT2OMuJsd75nqMQ.w7rlwNQzIB-F1hWOoWx17ozZ1Q9GAgH74IZmdvPrl30");
                var client = new SendGridClient("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");
                var from = new EmailAddress("tobiaswisoftware@gmail.com", "Kontaktformular");
                var subject = Email.Subject;
                var to = new EmailAddress("tobiaswisoftware@gmail.com", "x");
                var plainTextContent = Email.Message;
                var htmlContent = Email.Message + "<br>" + "<br>" + "Absender: " + Email.Email;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                Console.WriteLine(response.StatusCode);
                Email.IsSent = true;

            }
            catch (Exception ex)
            {
                Email.IsSent = false;
                await Console.Out.WriteLineAsync(ex.Message);
            }


        }
    }
}
