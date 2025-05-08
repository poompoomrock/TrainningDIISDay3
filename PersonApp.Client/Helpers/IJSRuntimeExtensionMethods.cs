using Microsoft.JSInterop;

namespace PersonApp.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime Js, string Message)
        {
            //await Js.InvokeVoidAsync("console.log", "log message");

            return await Js.InvokeAsync<bool>("confirm", Message);
        }
        public static async ValueTask MyFuntion(this IJSRuntime Js, string Message)
        {
            await Js.InvokeVoidAsync("my_function", Message);
        }
    }
}