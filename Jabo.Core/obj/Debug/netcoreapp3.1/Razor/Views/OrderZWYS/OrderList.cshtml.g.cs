#pragma checksum "D:\git\DotNetCore\Jabo.Core\Views\OrderZWYS\OrderList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8c994e4f068a93648f8a0f74051544ba81377a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderZWYS_OrderList), @"mvc.1.0.view", @"/Views/OrderZWYS/OrderList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8c994e4f068a93648f8a0f74051544ba81377a8", @"/Views/OrderZWYS/OrderList.cshtml")]
    public class Views_OrderZWYS_OrderList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""layuimini-container layuimini-page-anim"">
    <div class=""layuimini-main"">

        <fieldset class=""table-search-fieldset"">
            <legend>搜索信息</legend>
            <div style=""margin: 10px 10px 10px 10px"">
                <form class=""layui-form"" lay-filter=""form1""");
            BeginWriteAttribute("action", " action=\"", 290, "\"", 299, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""layui-form-item"">
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">订单号</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" name=""orderNo"" autocomplete=""off"" class=""layui-input"">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">仓易宝单号</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" name=""cYBNo"" autocomplete=""off"" class=""layui-input"">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">提货日期</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" name=""p");
            WriteLiteral(@"ickupDate"" class=""layui-input"" id=""pickupDate"" placeholder="" - "">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">收件人</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" name=""recipient"" autocomplete=""off"" class=""layui-input"">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">签收人</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" name=""signatory"" autocomplete=""off"" class=""layui-input"">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">签收日期</label>
                            <div cl");
            WriteLiteral(@"ass=""layui-input-inline"">
                                <input type=""text"" name=""signDate"" class=""layui-input"" id=""signDate"" placeholder="" - "">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <label class=""layui-form-label"">专营店号</label>
                            <div class=""layui-input-inline"">
                                <input type=""text"" name=""franchiseStore"" autocomplete=""off"" class=""layui-input"">
                            </div>
                        </div>
                        <div class=""layui-inline"">
                            <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon""></i> 搜 索</button>
                        </div>
                    </div>
                </form>
            </div>
        </fieldset>
        <script type=""text/html"" id=""toolbarDemo"">
            <div class=""layui-btn-contai");
            WriteLiteral(@"ner"">
                <button class=""layui-btn layui-btn-normal layui-btn-sm data-add-btn"" lay-event=""add"">添加</button>
                <button class=""layui-btn layui-btn-sm layui-btn-danger data-delete-btn"" lay-event=""delete"">删除</button>
                <button class=""layui-btn layui-btn-sm"" lay-event=""settle"">结算</button>
                <button class=""layui-btn layui-btn-sm layui-btn-warm"" lay-event=""exports"">导出</button>
            </div>
        </script>
        <table class=""layui-hide"" id=""currentTableId"" lay-filter=""currentTableFilter""></table>
        <script type=""text/html"" id=""currentTableBar"">
            <a class=""layui-btn layui-btn-warm layui-btn-xs data-count-view"" lay-event=""view"">查看</a>
            <a class=""layui-btn layui-btn-normal layui-btn-xs data-count-edit"" lay-event=""edit"">编辑</a>
            <a class=""layui-btn layui-btn-xs layui-btn-danger data-count-delete"" lay-event=""delete"">删除</a>
        </script>
    </div>
</div>

<script>
    layui.use(['form', 'table', 'mini");
            WriteLiteral(@"Page', 'element','laydate'], function () {
        var $ = layui.jquery,
            form = layui.form,
            table = layui.table,
            laydate = layui.laydate,
            miniPage = layui.miniPage;

        laydate.render({
            elem: '#pickupDate'
            , range: true
        });

        laydate.render({
            elem: '#signDate'
            , range: true
        });

        table.render({
            elem: '#currentTableId',
            url: '/OrderZWYS/GetOrderZWYSPage',
            toolbar: '#toolbarDemo',
            defaultToolbar: [],
            cols: [[
                { type: ""checkbox"", width: '5%', fixed: 'left' },
                { type: ""numbers"", width: '5%', title: '序号', fixed: 'left' },
                { field: 'orderNo', width: '15%', title: '订单号', align: 'center', fixed: 'left' },
                { field: 'cYBNo', width: '18%', title: '仓易宝单号', align: 'center' },
                { field: 'franchiseStore', width: '18%', title: '专营店号'");
            WriteLiteral(@", align: 'center' },
                { field: 'recipient', width: '8%', title: '收件人', align: 'center' },
                { field: 'pieces', width: '8%', title: '件数', align: 'center' },
                { field: 'pickupDate', width: '10%', title: '提货日期', align: 'center', templet: ""<div>{{layui.util.toDateString(d.pickupDate, 'yyyy-MM-dd')}}</div>"" },
                { field: 'signatory', width: '8%', title: '签收人', align: 'center' },
                { field: 'signDate', width: '10%', title: '签收日期', align: 'center', templet: ""<div>{{layui.util.toDateString(d.signDate, 'yyyy-MM-dd')}}</div>"" },
                { field: 'createDate', width: '10%', title: '创建日期', align: 'center', templet: ""<div>{{layui.util.toDateString(d.createDate, 'yyyy-MM-dd')}}</div>""  },
                { title: '操作', width: '15%', toolbar: '#currentTableBar', align: ""center"", fixed: 'right' }
            ]],
            limits: [10, 15, 20, 25, 50, 100],
            limit: 10,
            page: true,
            done: function (re");
            WriteLiteral(@"s, curr, count) {
                //判断某一列是图片的话，给下划线
                var re = res.data;
                if (re.length > 0) {
                    $.each(re, function (ii, dd) {
                        if (dd.settleState) {
                            $($("".layui-table-body.layui-table-main tr"")[ii]).css(""color"", ""#FF0000"");
                            $($(""div .layui-table-fixed.layui-table-fixed-l .layui-table-body tr"")[ii]).css(""color"", ""#FF0000"");
                        }
                    })
                }
            }
        });

        // 监听搜索操作
        form.on('submit(data-search-btn)', function (data) {

            //执行搜索重载
            table.reload('currentTableId', {
                page: {
                    curr: 1
                }
                , where: data.field

            }, 'data');

            return false;
        });

        /**
         * toolbar事件监听
         */
        table.on('toolbar(currentTableFilter)', function (obj) {
            if ");
            WriteLiteral(@"(obj.event === 'add') {   // 监听添加操作
                var index = layer.open({
                    title: '添加订单',
                    type: 2,
                    shade: 0.2,
                    shadeClose: true,
                    area: ['1100px', '700px'],
                    content: ""/OrderZWYS/OrderZWYSSave""
                });
                $(window).on(""resize"", function () {
                    layer.full(index);
                });
            } else if (obj.event === 'delete') {  // 监听删除操作
                var checkStatus = table.checkStatus('currentTableId')
                    , data = checkStatus.data;

                if (data.length === 0) {
                    layer.alert('请选择要删除的订单');
                    return
                }
                layer.confirm('您确定删除吗？', function (index) {
                    $.post(""/OrderZWYS/RemoveOrderZWYSByCode"", { list: data }, function (json) {
                        if (json.Result) {
                            table.reload('cur");
            WriteLiteral(@"rentTableId');
                        } else {
                            layer.msg(json.Message);
                        }
                    });
                    layer.close(index);
                });
            } else if (obj.event === 'settle') {  // 监听结算操作
                var checkStatus = table.checkStatus('currentTableId')
                    , data = checkStatus.data;

                if (data.length === 0) {
                    layer.alert('请选择要结算的订单');
                    return
                }
                layer.confirm('您确定结算吗？', function (index) {
                    $.post(""/OrderZWYS/SettleState"", { list: data }, function (json) {
                        if (json.Result) {
                            table.reload('currentTableId');
                        } else {
                            layer.msg(json.Message);
                        }
                    });
                    layer.close(index);
                });
            } else if (obj.event");
            WriteLiteral(@" === 'exports') {
                var data1 = form.val('form1');
                window.open('/OrderZWYS/Export?' + $.param(data1));
            }
        });

        //监听表格复选框选择
        table.on('checkbox(currentTableFilter)', function (obj) {
            //console.log(obj)
        });

        table.on('tool(currentTableFilter)', function (obj) {
            var data = obj.data;
            if (obj.event === 'edit') {
                var index = layer.open({
                    title: '编辑订单',
                    type: 2,
                    shade: 0.2,
                    shadeClose: true,
                    area: ['1100px', '700px'],
                    content: ""/OrderZWYS/OrderZWYSSave#/orderNo="" + data.orderNo,
                });
                $(window).on(""resize"", function () {
                    layer.full(index);
                });
            } else if (obj.event === 'delete') {
                layer.confirm('您确定删除吗？', function (index) {
                    $.post(");
            WriteLiteral(@"""/OrderZWYS/RemoveOrderZWYSByCode"", { list: [data] }, function (json) {
                        if (json.Result) {
                            table.reload('currentTableId');
                        } else {
                            layer.msg(json.Message);
                        }
                    }, ""json"");
                    layer.close(index);
                });
            } else if (obj.event === 'view') {
                var index = layer.open({
                    title: '查看订单',
                    type: 2,
                    shade: 0.2,
                    shadeClose: true,
                    area: ['1100px', '700px'],
                    content: ""/OrderZWYS/OrderZWYSView#/orderNo="" + data.orderNo,
                });
                $(window).on(""resize"", function () {
                    layer.full(index);
                });
                return false;
            }
        });

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
