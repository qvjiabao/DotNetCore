#pragma checksum "D:\git\DotNetCore\Jabo.Core\Views\User\UserSave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99826b8f73cb77cd369ea7dda6e945b1f400e8c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserSave), @"mvc.1.0.view", @"/Views/User/UserSave.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99826b8f73cb77cd369ea7dda6e945b1f400e8c4", @"/Views/User/UserSave.cshtml")]
    public class Views_User_UserSave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""layuimini-main"">
    <div class=""layui-form layuimini-form"">
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">用户账号</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""username"" lay-verify=""required"" lay-reqtext=""用户名不能为空"" placeholder=""请输入用户名""");
            BeginWriteAttribute("value", " value=\"", 341, "\"", 349, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">用户姓名</label>
            <div class=""layui-input-block"">
                <input type=""number"" name=""phone"" lay-verify=""required"" lay-reqtext=""手机不能为空"" placeholder=""请输入手机""");
            BeginWriteAttribute("value", " value=\"", 672, "\"", 680, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">性别</label>
            <div class=""layui-input-block"">
                <input type=""radio"" name=""sex"" value=""男"" title=""男""");
            BeginWriteAttribute("checked", " checked=\"", 955, "\"", 965, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <input type=""radio"" name=""sex"" value=""女"" title=""女"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">手机</label>
            <div class=""layui-input-block"">
                <input type=""number"" name=""phone"" lay-verify=""required"" lay-reqtext=""手机不能为空"" placeholder=""请输入手机""");
            BeginWriteAttribute("value", " value=\"", 1335, "\"", 1343, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <div class=""layui-input-block"">
                <button class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""saveBtn"">取消</button>
            </div>
        </div>
    </div>
</div>
<script>
    layui.use(['form'], function () {
        var form = layui.form;

        /**
         * 初始化表单，要加上，不然刷新部分组件可能会不加载
         */
        form.render();

        //表单初始赋值
        form.val('example', {
            ""username"": ""贤心"" // ""name"": ""value""
            , ""password"": ""123456""
            , ""interest"": 1
            , ""like[write]"": true //复选框选中状态
            , ""close"": true //开关状态
            , ""sex"": ""女""
            , ""desc"": ""我爱 layui""
        })
    });</script>");
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