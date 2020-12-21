using QJB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QJB.Shared;
using System.ComponentModel;
using AntDesign.TableModels;
using System.Collections;
using Newtonsoft.Json;
using AntDesign;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace QJB.Client.Pages.Settings.Users
{
    public partial class UserList
    {
        private string txtDisplayName { get; set; }

        [Inject]
        private HttpClient http { get; set; }

        IEnumerable<UserVModel> data;

        IEnumerable<UserVModel> selectedRows;
        ITable table;

        int _pageIndex = 1;
        int _pageSize = 10;
        int _total = 0;

        protected override async Task OnInitializedAsync()
        {
            await GetForecastAsync(_pageIndex, _pageSize, txtDisplayName);

            await InvokeAsync(StateHasChanged);
        }

        public async Task GetForecastAsync(int pageIndex, int pageSize, string displayName)
        {
            var str = await http.GetStringAsync($"User/GetUserList?pageIndex={pageIndex}&pageSize={pageSize}&displayName={displayName}");

            var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(str);

            _total = Convert.ToInt32(dic["total"]);

            data = JsonConvert.DeserializeObject<IEnumerable<UserVModel>>(dic["data"].ToString());

            await InvokeAsync(StateHasChanged);
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
    }
}
