#pragma checksum "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ab288560c8ead4e2eedda58ec4c491806d42a68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__ProductItem), @"mvc.1.0.view", @"/Views/Home/_ProductItem.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\_ViewImports.cshtml"
using IndianWebTradeWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\_ViewImports.cshtml"
using IndianWebTradeWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ab288560c8ead4e2eedda58ec4c491806d42a68", @"/Views/Home/_ProductItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58ba26fdbd15065cc3b869639e275d9dea7e0077", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home__ProductItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IndianWebTradeWeb.Models.ItemModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-3\">\r\n        <div class=\"item\">\r\n            <!-- Item img -->\r\n            <div class=\"item-img\">\r\n                <img class=\"img-1\"");
            BeginWriteAttribute("src", " src=\"", 246, "\"", 274, 2);
            WriteAttributeValue("", 252, "ItemImages/", 252, 11, true);
#nullable restore
#line 8 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
WriteAttributeValue("", 263, item.Image, 263, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 275, "\"", 281, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <!-- Overlay -->\r\n                <div class=\"overlay\">\r\n                    <div class=\"position-center-center\">\r\n                        <div class=\"inn\"><a");
            BeginWriteAttribute("href", " href=\"", 459, "\"", 488, 2);
            WriteAttributeValue("", 466, "ItemImages/", 466, 11, true);
#nullable restore
#line 12 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
WriteAttributeValue("", 477, item.Image, 477, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-lighter><i class=\"icon-magnifier\"></i></a> <a href=\"#.\"><i class=\"icon-basket\"");
            BeginWriteAttribute("onclick", " onclick=\"", 573, "\"", 602, 3);
            WriteAttributeValue("", 583, "addtocart(", 583, 10, true);
#nullable restore
#line 12 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
WriteAttributeValue("", 593, item.Id, 593, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 601, ")", 601, 1, true);
            EndWriteAttribute();
            WriteLiteral("></i></a> <a href=\"#.\"><i class=\"icon-heart\"></i></a></div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!-- Item Name -->\r\n            <div class=\"item-name\">\r\n                <a href=\"#.\">");
#nullable restore
#line 18 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                <p>");
#nullable restore
#line 19 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
              Write(item.Discription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <!-- Price -->\r\n            <span class=\"price\"><small>$</small>");
#nullable restore
#line 22 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
                                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mounth</span>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 25 "C:\Users\Admin\Source\Repos\IndianWebTrade\IndianWebTrade\IndianWebTradeWeb\Views\Home\_ProductItem.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IndianWebTradeWeb.Models.ItemModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
