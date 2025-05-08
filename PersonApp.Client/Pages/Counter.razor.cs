using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using PersonApp.Shared.Models;

namespace PersonApp.Client.Pages
{
    public partial class Counter
    {
        [Inject]
        public IJSRuntime js { get; set; }

        //[CascadingParameter (Name = "Color")]
        //public string Color { get; set; }

        //[CascadingParameter(Name = "Size")]
        //public string Size { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        [CascadingParameter]
        public AppState AppState { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        private string Color = "";

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationState;
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                Color = "Green";
            }
            else
            {
                Color = "brown";
            }
        }


        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }

        [JSInvokable]
        private async Task IncrementCount()
        {
            currentCount++;
            singleton.Value++;
            transient.Value++;
            scope.Value++;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }
        IJSObjectReference module;
        private async Task ShowAlert()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import","./js/Counter.js");
            await module.InvokeVoidAsync("displayAlert", "hello world","wachirawit");
        }
    }
}
