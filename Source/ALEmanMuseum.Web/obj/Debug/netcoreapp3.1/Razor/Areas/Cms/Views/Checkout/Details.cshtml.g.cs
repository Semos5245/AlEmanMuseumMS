#pragma checksum "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cde592c6a032b9256821596d695e941153a7cd4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cms_Views_Checkout_Details), @"mvc.1.0.view", @"/Areas/Cms/Views/Checkout/Details.cshtml")]
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
#line 1 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\_ViewImports.cshtml"
using ALEmanMuseum.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\_ViewImports.cshtml"
using ALEmanMuseum.Core.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\_ViewImports.cshtml"
using ALEmanMuseum.Web.Areas.Cms.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cde592c6a032b9256821596d695e941153a7cd4a", @"/Areas/Cms/Views/Checkout/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad58f7904eec18a426b70d38e056846fd6cdf1b3", @"/Areas/Cms/Views/_ViewImports.cshtml")]
    public class Areas_Cms_Views_Checkout_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckoutDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Details.cshtml"
   
    ViewData["Title"] = Localize["Checkout {0} details", Model.CheckoutNumber].Value;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<Program> Localize { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckoutDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
