#pragma checksum "C:\90Zgit\TennisPlayManager\TennisRanking\Views\MotivoBloqueio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2804fe374284a4ff0bef321c35565c40a29ec54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MotivoBloqueio_Index), @"mvc.1.0.view", @"/Views/MotivoBloqueio/Index.cshtml")]
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
#line 1 "C:\90Zgit\TennisPlayManager\TennisRanking\Views\_ViewImports.cshtml"
using TennisRanking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\90Zgit\TennisPlayManager\TennisRanking\Views\_ViewImports.cshtml"
using TennisRanking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2804fe374284a4ff0bef321c35565c40a29ec54", @"/Views/MotivoBloqueio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0dd2906f0d79a420650bab28714db570c5b6f0c", @"/Views/_ViewImports.cshtml")]
    public class Views_MotivoBloqueio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MotivoBloqueio>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\90Zgit\TennisPlayManager\TennisRanking\Views\MotivoBloqueio\Index.cshtml"
  
    ViewData["Title"] = "Motivo Bloqueio";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 8 "C:\90Zgit\TennisPlayManager\TennisRanking\Views\MotivoBloqueio\Index.cshtml"
     foreach (MotivoBloqueio motivo in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 10 "C:\90Zgit\TennisPlayManager\TennisRanking\Views\MotivoBloqueio\Index.cshtml"
       Write(motivo.Motivo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 11 "C:\90Zgit\TennisPlayManager\TennisRanking\Views\MotivoBloqueio\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MotivoBloqueio>> Html { get; private set; }
    }
}
#pragma warning restore 1591
