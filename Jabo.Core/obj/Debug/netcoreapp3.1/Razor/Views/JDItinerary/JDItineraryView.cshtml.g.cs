#pragma checksum "D:\git\DotNetCore\Jabo.Core\Views\JDItinerary\JDItineraryView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "243b18f032405eedbdc216699ece66bb31bc0f48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JDItinerary_JDItineraryView), @"mvc.1.0.view", @"/Views/JDItinerary/JDItineraryView.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"243b18f032405eedbdc216699ece66bb31bc0f48", @"/Views/JDItinerary/JDItineraryView.cshtml")]
    public class Views_JDItinerary_JDItineraryView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-layout-body layuimini-all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "243b18f032405eedbdc216699ece66bb31bc0f483135", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>燕翔嘉业货运管理系统</title>
    <meta name=""keywords"" content=""燕翔嘉业货运管理系统"">
    <meta name=""description"" content=""燕翔嘉业货运管理系统"">
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta http-equiv=""Access-Control-Allow-Origin"" content=""*"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
    <meta name=""apple-mobile-web-app-capable"" content=""yes"">
    <meta name=""format-detection"" content=""telephone=no"">
    <link rel=""icon"" href=""/images/favicon.ico"">
    <link rel=""stylesheet"" href=""/lib/layui-v2.5.5/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""/lib/font-awesome-4.7.0/css/font-awesome.min.css"" media=""all"">
    <link rel=""stylesheet"" href=""/css/layuimini.css?v=2.0.1"" media=""all"">
    <link rel=""stylesheet"" href=""/css/themes/default.css"" media=""all"">
    <link rel=""stylesheet");
                WriteLiteral("\" href=\"/css/public.css\" media=\"all\">\r\n    <style id=\"layuimini-bg-color\">\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "243b18f032405eedbdc216699ece66bb31bc0f485327", async() => {
                WriteLiteral(@"
    <div class=""layuimini-main"">
        <div class=""layui-form layuimini-form"" lay-filter=""example"">
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">始发站</label>
                <div class=""layui-input-block"">
                    <input type=""text"" name=""departure""");
                BeginWriteAttribute("value", " value=\"", 1514, "\"", 1522, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n                    <input type=\"hidden\" name=\"jDItineraryCode\"");
                BeginWriteAttribute("value", " value=\"", 1609, "\"", 1617, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">终点站</label>
                <div class=""layui-input-block"">
                    <input type=""text"" name=""terminal""");
                BeginWriteAttribute("value", " value=\"", 1892, "\"", 1900, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">行程(km)</label>
                <div class=""layui-input-block"">
                    <input type=""number"" name=""mileage""");
                BeginWriteAttribute("value", " value=\"", 2179, "\"", 2187, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">金额</label>
                <div class=""layui-input-block"">
                    <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-input-block"">
                    <button class=""layui-btn layui-btn-primary"" id=""btnClose"" lay-filter=""btnClose"">取消</button>
                </div>
            </div>
        </div>
    </div>
    <script src=""/lib/jquery-3.4.1/jquery-3.4.1.min.js"" charset=""utf-8""></script>
    <script src=""/lib/layui-v2.5.5/layui.js"" charset=""utf-8""></script>
    <script src=""/js/lay-config.js?v=2.0.0"" charset=""utf-8""></script>
    <script>
        layui.use(['form', 'table', 'element'], function () {
            var $ = layui.jquery,
                form = layui.form,
  ");
                WriteLiteral(@"              table = layui.table,
                router = layui.router();

            table.render({
                elem: '#currentTableId',
                url: '/JDItineraryCost/GetJDItineraryCostList?jDItineraryCode=' + router.search.jDItineraryCode,
                defaultToolbar: [],
                cols: [[
                    { type: ""numbers"", width: '10%', title: '序号' },
                    { field: 'carType', width: '30%', title: '货车车型', align: 'center' },
                    { field: 'cost', width: '30%', title: '金额', align: 'center' },
                    { field: 'createDate', width: '30%', title: '创建日期', align: 'center', templet: ""<div>{{layui.util.toDateString(d.createDate, 'yyyy-MM-dd')}}</div>"" },
                ]],
                limits: [10, 15, 20, 25, 50, 100],
                limit: 10,
                height:380,
                page: true
            });

            var router = layui.router();

            if (router.search.jDItineraryCode != undefined && r");
                WriteLiteral(@"outer.search.jDItineraryCode !== """") {

                $.get(""/JDItinerary/GetJDItineraryByCode"", { jDItineraryCode: router.search.jDItineraryCode }, function (json) {            //表单初始赋值
                    form.val('example', {
                        ""jDItineraryCode"": json.jDItineraryCode
                        , ""departure"": json.departure
                        , ""terminal"": json.terminal
                        , ""mileage"": json.mileage
                    });
                });
            }

            var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引

            layui.$('#btnClose').on('click', function () {
                parent.layer.close(index); //再执行关闭
            });
        });</script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
