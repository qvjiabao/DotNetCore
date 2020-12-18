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
#line 3 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserList.razor"
using QJB.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserList.razor"
using System.ComponentModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserList.razor"
using AntDesign.TableModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserList.razor"
using System.Collections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserList.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Setting/User/UserList")]
    public partial class UserList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 61 "D:\git\DotNetCore\QJB\Client\Pages\Settings\Users\UserList.razor"
       

    string txtValue { get; set; }

    IEnumerable<UserVModel> data;

    IEnumerable<UserVModel> selectedRows;
    ITable table;

    int _pageIndex = 1;
    int _pageSize = 10;
    int _total = 0;

    protected override async Task OnInitializedAsync()
    {
        await GetForecastAsync(_pageIndex, _pageSize);
    }

    public async Task GetForecastAsync(int pageIndex, int pageSize)
    {
        var str = await http.GetStringAsync("User/GetUserList");

        var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(str);

        _total = Convert.ToInt32(dic["total"]);

        data = JsonConvert.DeserializeObject<IEnumerable<UserVModel>>(dic["data"].ToString());
    }

    public void RemoveSelection(string userCode)
    {
        //var selected = selectedRows.Where(x => x.Id != id);
        //selectedRows = selected;

        //table.SetSelection(selected.Select(x => x.Id.ToString()).ToArray());
    }

    private void Delete(string userCode)
    {
        //forecasts = forecasts.Where(x => x.Id != id).ToArray();
        //_total = forecasts.Length;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
