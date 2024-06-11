using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using SendGrid;
using SendGrid.Helpers.Mail;
using SharedLibrary.Dtos;
using System;
using Microsoft.AspNetCore.Components.Web;



namespace BlazorServer.Pages
{
    public partial class Index
    {

    


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Blazor.aos_init", DotNetObjectReference.Create(this));

            }
        }



    


        public Index()
        {


           
        }
    }
}

