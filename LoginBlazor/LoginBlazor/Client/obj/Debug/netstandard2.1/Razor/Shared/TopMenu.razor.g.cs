#pragma checksum "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\Shared\TopMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea0ad233bf17be75414cb3b95b9ae32046f5b181"
// <auto-generated/>
#pragma warning disable 1591
namespace LoginBlazor.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using LoginBlazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using LoginBlazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    public partial class TopMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "div");
                __builder2.AddAttribute(3, "class", "top-menu");
                __builder2.OpenElement(4, "button");
                __builder2.AddAttribute(5, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\Shared\TopMenu.razor"
                              Logout

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(6, "Logout");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(7, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(8, "div");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(9);
                __builder2.AddAttribute(10, "href", "");
                __builder2.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(12, "Login");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(13, " |\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(14);
                __builder2.AddAttribute(15, "href", "register");
                __builder2.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(17, "Register");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "C:\Users\LENOVO\source\repos\LoginBlazor\LoginBlazor\Client\Shared\TopMenu.razor"
      
    private async void Logout()
    {
        await LocalStorage.RemoveItemAsync("authToken");
        await AuthStateProvider.GetAuthenticationStateAsync();
        NavigationManager.NavigateTo("/");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthStateProvider { get; set; }
    }
}
#pragma warning restore 1591
