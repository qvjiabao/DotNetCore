#pragma checksum "D:\git\DotNetCore\Jabo.Core\Views\OrderZWYS\OrderZWYSSave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2355e3e05d2fdd4b116a3d4b04b1d1f342a05ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderZWYS_OrderZWYSSave), @"mvc.1.0.view", @"/Views/OrderZWYS/OrderZWYSSave.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2355e3e05d2fdd4b116a3d4b04b1d1f342a05ca", @"/Views/OrderZWYS/OrderZWYSSave.cshtml")]
    public class Views_OrderZWYS_OrderZWYSSave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2355e3e05d2fdd4b116a3d4b04b1d1f342a05ca3115", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2355e3e05d2fdd4b116a3d4b04b1d1f342a05ca5307", async() => {
                WriteLiteral(@"
    <div class=""layuimini-main"">
        <div class=""layui-form layuimini-form"" lay-filter=""example"">
            <div class=""layui-form-item"">
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">订单号</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""orderNo"" lay-verify=""required"" readonly lay-reqtext=""订单号不能为空"" placeholder=""请输入订单号""");
                BeginWriteAttribute("value", " value=\"", 1652, "\"", 1660, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                        <input type=""hidden"" name=""orderId"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">仓易宝单号</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""cYBNo"" lay-verify=""required"" lay-reqtext=""仓易宝单号不能为空"" placeholder=""请输入仓易宝单号""");
                BeginWriteAttribute("value", " value=\"", 2096, "\"", 2104, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">提货日期</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""pickupDate"" id=""pickupDate"" placeholder=""yyyy年MM月dd日"" lay-verify=""date"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">专营店号</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" id=""franchiseStore"" name=""franchiseStore"" lay-verify=""required"" lay-reqtext=""专营店号不能为空"" placeholder=""请输入专营店号""");
                BeginWriteAttribute("value", " value=\"", 2954, "\"", 2962, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">收件人</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""recipient"" lay-verify=""required"" lay-reqtext=""收件人不能为空"" placeholder=""请输入收件人""");
                BeginWriteAttribute("value", " value=\"", 3334, "\"", 3342, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">电话</label>
                    <div class=""layui-input-inline"">
                        <input type=""tel"" name=""phone"" lay-verify=""required|phone"" lay-reqtext=""电话不能为空"" placeholder=""请输入电话""");
                BeginWriteAttribute("value", " value=\"", 3712, "\"", 3720, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">门店星级</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""storeStar"" lay-verify=""required"" lay-reqtext=""门店星级不能为空"" placeholder=""请输入门店星级""");
                BeginWriteAttribute("value", " value=\"", 4158, "\"", 4166, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">城市等级</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""cityLevel"" lay-verify=""required"" lay-reqtext=""城市等级不能为空"" placeholder=""请输入城市等级""");
                BeginWriteAttribute("value", " value=\"", 4541, "\"", 4549, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">件数</label>
                    <div class=""layui-input-inline"">
                        <input type=""number"" name=""pieces"" lay-verify=""required"" lay-reqtext=""件数不能为空"" placeholder=""请输入件数""");
                BeginWriteAttribute("value", " value=\"", 4917, "\"", 4925, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"" id=""area-picker"">
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">省市区</label>
                    <div class=""layui-input-inline"">
                        <select name=""provinceName"" class=""province-selector"" lay-verify=""required"" lay-filter=""province-1"">
                            <option");
                BeginWriteAttribute("value", " value=\"", 5414, "\"", 5422, 0);
                EndWriteAttribute();
                WriteLiteral(@">请选择省</option>
                        </select>
                        <input type=""hidden"" name=""provinceCode"">
                    </div>
                    <div class=""layui-input-inline"">
                        <select name=""cityName"" class=""city-selector"" lay-verify=""required"" lay-filter=""city-1"">
                            <option");
                BeginWriteAttribute("value", " value=\"", 5772, "\"", 5780, 0);
                EndWriteAttribute();
                WriteLiteral(@">请选择市</option>
                        </select>
                        <input type=""hidden"" name=""cityCode"">
                    </div>
                    <div class=""layui-input-inline"">
                        <select name=""areaName"" class=""county-selector"" lay-verify=""required"" lay-filter=""county-1"">
                            <option");
                BeginWriteAttribute("value", " value=\"", 6130, "\"", 6138, 0);
                EndWriteAttribute();
                WriteLiteral(@">请选择区</option>
                        </select>
                        <input type=""hidden"" name=""areaCode"">
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-block"">
                    <label class=""layui-form-label required"">收货地址</label>
                    <div class=""layui-input-block"">
                        <textarea placeholder=""请输入内容"" lay-verify=""required"" lay-reqtext=""收货地址不能为空"" name=""address"" class=""layui-textarea""></textarea>
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">签收人</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""signatory"" lay-verify=""required"" lay-reqtext=""签收人不能为空"" placeholder=""请输入签收人""");
                BeginWriteAttribute("value", " value=\"", 7100, "\"", 7108, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
                    </div>
                </div>
                <div class=""layui-inline"">
                    <label class=""layui-form-label required"">签收日期</label>
                    <div class=""layui-input-inline"">
                        <input type=""text"" name=""signDate"" id=""signDate"" lay-verify=""date"" placeholder=""yyyy年MM月dd日"" autocomplete=""off"" class=""layui-input"">
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-block"">
                    <label class=""layui-form-label"">备注</label>
                    <div class=""layui-input-block"">
                        <textarea placeholder=""请输入内容"" name=""remark"" class=""layui-textarea""></textarea>
                    </div>
                </div>
            </div>
            <div class=""layui-form-item"">
                <div class=""layui-block"">
                    <div class=""layui-input-block"">
                        <but");
                WriteLiteral("ton class=\"layui-btn\"");
                BeginWriteAttribute("lay-submit", " lay-submit=\"", 8154, "\"", 8167, 0);
                EndWriteAttribute();
                WriteLiteral(@" lay-filter=""btnSave"">保存</button>
                        <button class=""layui-btn layui-btn-primary"" id=""btnClose"" lay-filter=""btnClose"">取消</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src=""/lib/jquery-3.4.1/jquery-3.4.1.min.js"" charset=""utf-8""></script>
    <script src=""/lib/layui-v2.5.5/layui.js"" charset=""utf-8""></script>
    <script src=""/js/lay-config.js?v=2.0.0"" charset=""utf-8""></script>
    <script>
        layui.use(['form', 'layer', 'laydate', 'tableSelect', 'layarea'], function () {
            var form = layui.form,
                laydate = layui.laydate,
                layarea = layui.layarea;

            //日期
            laydate.render({
                elem: '#pickupDate'
            });
            laydate.render({
                elem: '#signDate'
            });


            var tableSelect = layui.tableSelect;
            tableSelect.render({
                elem: '#franchiseStore',	//定义输入框i");
                WriteLiteral(@"nput对象 必填
                checkedKey: 'id', //表格的唯一建值，非常重要，影响到选中状态 必填
                searchKey: 'franchiseStore',	//搜索输入框的name值 默认keyword
                searchPlaceholder: '关键词搜索',	//搜索输入框的提示文字 默认关键词搜索
                table: {	//定义表格参数，与LAYUI的TABLE模块一致，只是无需再定义表格elem
                    url: '/OrderZWYS/GetOrderZWYSByFranchiseStore',
                    cols: [[
                        { type: ""numbers"", width: '10%', title: '序号', fixed: 'left' },
                        { field: 'franchiseStore', width: '90%', title: '专营店号', align: 'center' }
                    ]]
                },
                done: function (elem, data) {
                    var NEWJSON = []
                    layui.each(data.data, function (index, item) {
                        NEWJSON.push(item.franchiseStore)
                    })
                    elem.val(NEWJSON.join("",""))
                }
            })

            /**
             * 初始化表单，要加上，不然刷新部分组件可能会不加载
             */
            form.render");
                WriteLiteral(@"();

            var router = layui.router();

            if (router.search.orderNo != undefined && router.search.orderNo !== """") {
                $.get(""/OrderZWYS/GetOrderZWYSByOrderNo"", { orderNo: router.search.orderNo }, function (json) {            //表单初始赋值
                    form.val('example', {
                        ""orderNo"": json.orderNo
                        , ""cYBNo"": json.cYBNo
                        , ""franchiseStore"": json.franchiseStore
                        , ""recipient"": json.recipient
                        , ""phone"": json.phone
                        , ""storeStar"": json.storeStar
                        , ""cityLevel"": json.cityLevel
                        , ""pieces"": json.pieces
                        , ""address"": json.address
                        , ""signatory"": json.signatory
                        , ""remark"": json.remark
                        , ""pickupDate"": json.pickupDate.substr(0, 10)
                        , ""signDate"": json.signDate.substr(0, ");
                WriteLiteral(@"10)
                        , ""orderId"": json.orderId
                        , ""provinceCode"": json.provinceCode
                        , ""cityCode"": json.cityCode
                        , ""areaCode"": json.areaCode
                    });

                    layarea.render({
                        elem: '#area-picker',
                        data: {
                            province: json.provinceName,
                            city: json.cityName,
                            county: json.areaName
                        },
                        change: function (res) {
                            //选择结果
                            $(""input[name='provinceCode']"").val(res.provinceCode);
                            $(""input[name='cityCode']"").val(res.cityCode);
                            $(""input[name='areaCode']"").val(res.countyCode);
                        }
                    });
                });
            }
            else {
                layarea.render({
   ");
                WriteLiteral(@"                 elem: '#area-picker',
                    change: function (res) {
                        //选择结果
                        $(""input[name='provinceCode']"").val(res.provinceCode);
                        $(""input[name='cityCode']"").val(res.cityCode);
                        $(""input[name='areaCode']"").val(res.countyCode);
                    }
                });
            }

            var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引

            form.on('submit(btnSave)', function (data) {
                data = data.field;
                $.post(""/OrderZWYS/SaveOrderZWYS"", data, function (json) {
                    if (json.Result) {
                        layer.msg(json.Message, { shift: -1, time: 1000 }, function () {
                            parent.layui.table.reload('currentTableId');
                            parent.layer.close(index); //再执行关闭
                        });
                    } else {
                        layer.msg(js");
                WriteLiteral(@"on.Message);
                        return false;
                    }
                }, ""json"");
            });

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