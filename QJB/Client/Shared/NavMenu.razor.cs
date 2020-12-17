using Microsoft.AspNetCore.Components;
using QJB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QJB.Client.Shared
{
    public partial class NavMenu
    {
        [Inject]
        HttpClient Http { get; set; }

        private IEnumerable<MenuVModel> menuList = new List<MenuVModel>();

        protected override async Task OnInitializedAsync()
        {
            menuList = await Http.GetFromJsonAsync<IEnumerable<MenuVModel>>("Home/GetAllMenu");

            base.OnInitializedAsync();
        }
    }
}
