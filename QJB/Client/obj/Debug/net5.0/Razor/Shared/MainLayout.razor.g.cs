#pragma checksum "D:\git\DotNetCore\QJB\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3aa96323a97e402cb172e567ca202858d72cc91f"
// <auto-generated/>
#pragma warning disable 1591
namespace QJB.Client.Shared
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
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<AntDesign.Layout>(0);
            __builder.AddAttribute(1, "Style", "height:100%;");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<AntDesign.Sider>(3);
                __builder2.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(5, "<div class=\"logo\" b-pwpok6v3i2></div>\r\n        ");
                    __builder3.OpenComponent<QJB.Client.Shared.NavMenu>(6);
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenComponent<AntDesign.Layout>(8);
                __builder2.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<AntDesign.Header>(10);
                    __builder3.AddAttribute(11, "Class", "site-layout-sub-header-background");
                    __builder3.AddAttribute(12, "Style", "padding: 0;");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(13, "\r\n        ");
                    __builder3.OpenComponent<AntDesign.Content>(14);
                    __builder3.AddAttribute(15, "Style", " margin: 24px 16px 0;");
                    __builder3.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<AntDesign.Breadcrumb>(17);
                        __builder4.AddAttribute(18, "Style", "margin: 16px 0;");
                        __builder4.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<AntDesign.BreadcrumbItem>(20);
                            __builder5.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(22, "Home");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(23, "\r\n                ");
                            __builder5.OpenComponent<AntDesign.BreadcrumbItem>(24);
                            __builder5.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(26, "List");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(27, "\r\n                ");
                            __builder5.OpenComponent<AntDesign.BreadcrumbItem>(28);
                            __builder5.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(30, "App");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(31, "\r\n            ");
                        __builder4.OpenElement(32, "div");
                        __builder4.AddAttribute(33, "class", "site-layout-background");
                        __builder4.AddAttribute(34, "b-pwpok6v3i2");
                        __builder4.AddContent(35, 
#nullable restore
#line 19 "D:\git\DotNetCore\QJB\Client\Shared\MainLayout.razor"
                 Body

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(36, "\r\n        ");
                    __builder3.OpenComponent<AntDesign.Footer>(37);
                    __builder3.AddAttribute(38, "Style", "text-align: center;");
                    __builder3.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(40, "Ant Design ©2018 Created by Ant UED");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(41, "\r\n\r\n");
            __builder.AddMarkupContent(42, @"<style b-pwpok6v3i2>
    #components-layout-demo-responsive .logo {
        height: 32px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px;
    }

    .site-layout-sub-header-background {
        background: #fff;
    }

    .site-layout-background {
        background: #fff;
        padding: 24px;
        min-height: 360px;
        height: calc(100vh - 224px);
        overflow: auto;
    }
</style>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
