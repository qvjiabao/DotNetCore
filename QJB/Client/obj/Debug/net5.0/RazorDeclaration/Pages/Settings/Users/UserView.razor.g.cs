// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace QJB.Client.Pages.Settings.Users
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using QJB.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using QJB.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\git\DotNetCore\QJB\Client\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserView.razor"
using QJB.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserView.razor"
using QJB.Shared.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserView.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserView.razor"
using QJB.Shared.Attribute.Common;

#line default
#line hidden
#nullable disable
    public partial class UserView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserView.razor"
      

    private CustomValidator _customValidator { get; set; }

    [Parameter]
    public UserVModel _userInfo { get; set; }

    [Parameter]
    public bool _visible { get; set; }

    [Parameter]
    public EventCallback _evenCloseUserView { get; set; }

    [Parameter]
    public EventCallback _eventInitDataGrid { get; set; }

    [Parameter]
    public Action<EditContext> _onFinishFailed { get; set; }

    public void ClearErrors()
    {
        _customValidator.ClearErrors();
    }

    private async Task _onFinish(EditContext editContext)
    {
        _customValidator.ClearErrors();

        var errors = new Dictionary<string, List<string>>();

        if (string.IsNullOrEmpty(_userInfo.UserName))
        {
            errors.Add(nameof(_userInfo.UserName), new List<string>() { "请输入用户账号" });
        }

        if (string.IsNullOrEmpty(_userInfo.DisplayName))
        {
            errors.Add(nameof(_userInfo.DisplayName), new List<string>() { "请输入用户姓名" });
        }

        if (string.IsNullOrEmpty(_userInfo.Phone))
        {
            errors.Add(nameof(_userInfo.Phone), new List<string>() { "请输入手机号" });
        }

        if (string.IsNullOrEmpty(_userInfo.Sex))
        {
            errors.Add(nameof(_userInfo.Sex), new List<string>() { "请选择性别" });
        }

        if (errors.Count() > 0)
        {
            _customValidator.DisplayErrors(errors);
        }
        else
        {
            var responseMessage = await http.PostAsJsonAsync($"User/SaveUserInfo", _userInfo);
            var strJson = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HttpJsonResult>(strJson);
            if (result.Result)
            {
                _message.Success(result.Message);
                _evenCloseUserView.InvokeAsync();
                _eventInitDataGrid.InvokeAsync();
            }
            else
            {
                _message.Error(result.Message);
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MessageService _message { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
