#pragma checksum "D:\git\DotNetCore\QJB\Client\Pages\Component.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e76b757ebfdae6267b298f42077f6eef9db8b390"
// <auto-generated/>
#pragma warning disable 1591
namespace QJB.Client.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/Component")]
    public partial class Component : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<AntDesign.AntList<BasicItem>>(0);
            __builder.AddAttribute(1, "DataSource", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<BasicItem>>(
#nullable restore
#line 3 "D:\git\DotNetCore\QJB\Client\Pages\Component.razor"
                      data

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnItemClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<BasicItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<BasicItem>(this, 
#nullable restore
#line 3 "D:\git\DotNetCore\QJB\Client\Pages\Component.razor"
                                                           ItemClick

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<BasicItem>)((context) => (__builder2) => {
                __builder2.OpenComponent<AntDesign.ListItem>(4);
                __builder2.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<AntDesign.ListItemMeta>(6);
                    __builder3.AddAttribute(7, "Avatar", "avatar");
                    __builder3.AddAttribute(8, "Description", "Ant Design, a design language for background applications, is refined by Ant UED Team");
                    __builder3.AddAttribute(9, "TitleTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(10, "a");
                        __builder4.AddAttribute(11, "href", "https://ng.ant.design");
                        __builder4.AddContent(12, 
#nullable restore
#line 7 "D:\git\DotNetCore\QJB\Client\Pages\Component.razor"
                                                 context.Title

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "D:\git\DotNetCore\QJB\Client\Pages\Component.razor"
      

    RenderFragment avatar =

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.OpenComponent<AntDesign.Avatar>(13);
            __builder2.AddAttribute(14, "Src", "https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png");
            __builder2.CloseComponent();
        }
#nullable restore
#line 15 "D:\git\DotNetCore\QJB\Client\Pages\Component.razor"
                                                                                                                    ;

public class BasicItem
{
public string Title { get; set; }
}

public List<BasicItem> data = new List<BasicItem>
{
        new BasicItem { Title = "Ant Design Title 1"},
        new BasicItem { Title = "Ant Design Title 2"},
        new BasicItem { Title = "Ant Design Title 3"},
        new BasicItem { Title = "Ant Design Title 4"},
    };

public void ItemClick(BasicItem item)
{
Console.WriteLine($"item was clicked: {item.Title}");
}

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
