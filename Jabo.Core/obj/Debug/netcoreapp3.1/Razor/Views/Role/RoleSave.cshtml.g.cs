#pragma checksum "D:\git\DotNetCore\Jabo.Core\Views\Role\RoleSave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84367a842d7111c00b1929ab1e5ad96c3b843aae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_RoleSave), @"mvc.1.0.view", @"/Views/Role/RoleSave.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84367a842d7111c00b1929ab1e5ad96c3b843aae", @"/Views/Role/RoleSave.cshtml")]
    public class Views_Role_RoleSave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84367a842d7111c00b1929ab1e5ad96c3b843aae3065", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84367a842d7111c00b1929ab1e5ad96c3b843aae5257", async() => {
                WriteLiteral(@"
    <div class=""layuimini-main"">
        <div class=""layui-form layuimini-form"" lay-filter=""example"">
            <div class=""layui-form-item"">
                <label class=""layui-form-label required"">角色名称</label>
                <div class=""layui-input-block"">
                    <input type=""text"" name=""roleName"" lay-verify=""required"" lay-reqtext=""角色名称不能为空"" placeholder=""请输入角色名称""");
                BeginWriteAttribute("value", " value=\"", 1590, "\"", 1598, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n                    <input type=\"hidden\" name=\"roleCode\"");
                BeginWriteAttribute("value", " value=\"", 1678, "\"", 1686, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">描述</label>
                <div class=""layui-input-block"">
                    <textarea placeholder=""请输入内容"" name=""describe"" class=""layui-textarea""></textarea>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-input-block"">
                    <button class=""layui-btn""");
                BeginWriteAttribute("lay-submit", " lay-submit=\"", 2189, "\"", 2202, 0);
                EndWriteAttribute();
                WriteLiteral(@" lay-filter=""btnSave"">保存</button>
                    <button class=""layui-btn layui-btn-primary"" id=""btnClose"" lay-filter=""btnClose"">取消</button>
                </div>
            </div>
        </div>
    </div>
    <script src=""/lib/jquery-3.4.1/jquery-3.4.1.min.js"" charset=""utf-8""></script>
    <script src=""/lib/layui-v2.5.5/layui.js"" charset=""utf-8""></script>
    <script src=""/js/lay-config.js?v=2.0.0"" charset=""utf-8""></script>
    <script>
        layui.use(['form', 'layer'], function () {
            var form = layui.form;

            /**
             * 初始化表单，要加上，不然刷新部分组件可能会不加载
             */
            form.render();

            var router = layui.router();

            if (router.search.roleCode != undefined && router.search.roleCode !== """") {

                $.post(""/Role/GetRoleByCode"", { roleCode: router.search.roleCode }, function (json) {            //表单初始赋值
                    form.val('example', {
                        ""roleCode"": json.roleCode
                 ");
                WriteLiteral(@"       , ""roleName"": json.roleName
                        , ""describe"": json.describe
                    });
                });
            }

            var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引

            form.on('submit(btnSave)', function (data) {
                data = data.field;
                $.post(""/Role/SaveRoleInfo"", data, function (json) {
                    if (json.Result) {
                        layer.msg(json.Message, { shift: -1, time: 1000 }, function () {
                            parent.layui.table.reload('currentTableId');
                            parent.layer.close(index); //再执行关闭
                        });
                    } else {
                        layer.msg(json.Message);
                        return false;
                    }
                }, ""json"");
            });

            layui.$('#btnClose').on('click', function () {
                parent.layer.close(index); //再执行关闭
            });
      ");
                WriteLiteral("  });</script>\r\n");
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
