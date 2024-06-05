using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using SendGrid;
using SendGrid.Helpers.Mail;
using SharedLibrary.Dtos;
using System;



namespace BlazorServer.Pages
{
    public partial class Index
    {
        public List<SectionComponentProjectsDto> SectionComponentItems { get; set; } = new();

        public EmailDto EmailDto { get; set; }

        private ElementReference backToTopButton;
        private string ButtonClass => isVisible ? "active" : "";

        private bool isVisible;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Blazor.registerBackToTop", DotNetObjectReference.Create(this));
            }
        }



        [JSInvokable]
        public async Task UpdateVisibility(double scrollPosition)
        {
            var shouldShow = scrollPosition > 100;
            if (isVisible != shouldShow)
            {
                isVisible = shouldShow;
                StateHasChanged();
            }
        }

        public async Task ScrollToTop()
        {
            await JSRuntime.InvokeVoidAsync("window.scrollTo", 0, 0);
        }

        public void Dispose()
        {
            JSRuntime.InvokeVoidAsync("Blazor.deregisterBackToTop");
        }


        public Index()
        {
            SectionComponentItems.Add(new SectionComponentProjectsDto(
                1,
                "Frontend templates /test",
                "Frontend designs for excellent, modern and responsive user interfaces /test",

                new List<string> { "Pictures/projects/frontend_blazor.png", "Pictures/projects/backend_java_1.png" },

                "Tax Calculator UI made with Blazor",

                @"A simple responsive bootstrap and css design. Check out the <a href='https://brutto-netto-steuerrechner.de' 
                target='_blank'>live version</a> and <a href='https://github.com/TobiasWiSoftware/TaxCalculatorWithAPI' target='_blank'>source code</a>.",

                new List<string> { "Pictures/projects/frontend_blazor.png", "Pictures/projects/backend_java_1.png" }));

        }

     


        public async Task TaskSendEmail()
        {
            try
            {
                var Client = new SendGridClient("CQCOqyTHFi171tD13ertHi5l8ffMBoFX");
                var to = new EmailAddress("tobiaswisoftware@gmail.com");
                var from = new EmailAddress(EmailDto.Email, EmailDto.Name);
                var msg = MailHelper.CreateSingleEmail(from, to, EmailDto.Subject, EmailDto.Message, EmailDto.Message);
                var response = await Client.SendEmailAsync(msg);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }


        }
    }
}
