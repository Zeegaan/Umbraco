#pragma checksum "C:\Users\lebee\Documents\GitHub\Umbraco\UmbracoProjekt\UmbracoProjekt\Views\Form\CreateNumbers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14c54e3ab405b853681f7a9e96b1c708224a3f98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Form_CreateNumbers), @"mvc.1.0.view", @"/Views/Form/CreateNumbers.cshtml")]
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
#line 1 "C:\Users\lebee\Documents\GitHub\Umbraco\UmbracoProjekt\UmbracoProjekt\Views\_ViewImports.cshtml"
using UmbracoProjekt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lebee\Documents\GitHub\Umbraco\UmbracoProjekt\UmbracoProjekt\Views\_ViewImports.cshtml"
using UmbracoProjekt.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14c54e3ab405b853681f7a9e96b1c708224a3f98", @"/Views/Form/CreateNumbers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07c903f9f9dadf9ecc86947437ebe92df684575", @"/Views/_ViewImports.cshtml")]
    public class Views_Form_CreateNumbers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\lebee\Documents\GitHub\Umbraco\UmbracoProjekt\UmbracoProjekt\Views\Form\CreateNumbers.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Enter number: ");
#nullable restore
#line 6 "C:\Users\lebee\Documents\GitHub\Umbraco\UmbracoProjekt\UmbracoProjekt\Views\Form\CreateNumbers.cshtml"
                Write(Html.TextBox("count"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <input type=\"submit\" value=\"Submit\" class=\"btn-default\" />\r\n");
#nullable restore
#line 8 "C:\Users\lebee\Documents\GitHub\Umbraco\UmbracoProjekt\UmbracoProjekt\Views\Form\CreateNumbers.cshtml"
}

#line default
#line hidden
#nullable disable
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
