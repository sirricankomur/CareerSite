#pragma checksum "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fac3473c0aca7115fc6e79bfe7e8f7a51f9d723e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__navbar), @"mvc.1.0.view", @"/Views/Shared/_navbar.cshtml")]
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
#line 2 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\_ViewImports.cshtml"
using CareerSite.Entity.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\_ViewImports.cshtml"
using CareerSite.MvcWebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\_ViewImports.cshtml"
using CareerSite.MvcWebUI.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\_ViewImports.cshtml"
using CareerSite.MvcWebUI.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fac3473c0aca7115fc6e79bfe7e8f7a51f9d723e", @"/Views/Shared/_navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4ffcd7bc7b9081e83a945ec8bd0a9f7f114214", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <header class=\"blog-header py-3\">\r\n        <div class=\"row flex-nowrap justify-content-between align-items-center\">\r\n            <div class=\"col-4 pt-3 d-flex justify-content-start align-items-center\">\r\n\r\n\r\n");
#nullable restore
#line 71 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml"
                 if (User.Identity.IsAuthenticated)
                {
                    if (User.IsInRole("admin"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"pr-3\">\r\n\r\n                            <a class=\"btn btn-sm btn-outline-danger\" href=\"/dashboard\">Admin Paneli</a>\r\n\r\n");
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 92 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fac3473c0aca7115fc6e79bfe7e8f7a51f9d723e5488", async() => {
                WriteLiteral(@"
                        <div class=""input-group input-group-sm"">

                            <input name=""q"" type=""text"" class=""form-control"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-sm"" placeholder=""Ara"">
                            <div class=""input-group-append"">
                                <button class=""btn btn-outline-dark"" type=""submit"" id=""button-addon2"">
                                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""17"" height=""17"" fill=""currentColor"" class=""bi bi-search"" viewBox=""0 0 16 16"">
                                        <path d=""M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z""></path>
                                    </svg>
                                </button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                </div>



            </div>
            <div class=""col-4 pt-3 text-center"">
                <a class=""blog-header-logo text-dark"" href=""/home/index"">CareerSite</a>
            </div>
            <div class=""col-4 pt-3 d-flex justify-content-end align-items-center"">

                <div class=""pr-3"">
                    <a class=""text-body"" href=""/cart"" title=""Sepet"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""19"" height=""19"" fill=""currentColor"" class=""bi bi-bag-check"" viewBox=""0 0 16 16"">
                            <path fill-rule=""evenodd"" d=""M10.854 8.146a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708 0l-1.5-1.5a.5.5 0 0 1 .708-.708L7.5 10.793l2.646-2.647a.5.5 0 0 1 .708 0z""></path>
                            <path d=""M8 1a2.5 2.5 0 0 1 2.5 2.5V4h-5v-.5A2.5 2.5 0 0 1 8 1zm3.5 3v-.5a3.5 3.5 0 1 0-7 0V4H1v10a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V4h-3.5zM2 5h12v9a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V5z""></path>
                        </svg>
                    </");
            WriteLiteral("a>\r\n                </div>\r\n\r\n");
#nullable restore
#line 128 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml"
                 if (User.Identity.IsAuthenticated)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""dropdown"">
                        <button class=""btn btn-sm btn-outline-success dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            ");
#nullable restore
#line 132 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml"
                       Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </button>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                            <a class=""dropdown-item"" href=""/records"">Kayıtlar</a>
                            <a class=""dropdown-item text-danger"" href=""/account/logout"">Çıkış</a>
                        </div>
                    </div>
");
#nullable restore
#line 139 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""mr-2"">
                        <a class=""btn btn-sm btn-outline-success"" href=""/account/login"">Giriş</a>
                    </div>
                    <div>
                        <a class=""btn btn-sm btn-outline-primary"" href=""/account/register"">Kayıt Ol</a>
                    </div>
");
#nullable restore
#line 148 "A:\CareerSiteDemo\CareerSiteDemo\CareerSite.MvcWebUI\Views\Shared\_navbar.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </header>

    <div class=""nav-scroller py-1 mb-2"">
        <nav class=""nav d-flex justify-content-between"">
            <a class=""p-2 text-muted"" href=""/courses/yazilim"">Yazılım</a>
            <a class=""p-2 text-muted"" href=""/courses/saglik"">Sağlık</a>
            <a class=""p-2 text-muted"" href=""/courses/muzik"">Müzik</a>
            <a class=""p-2 text-muted"" href=""/courses/akademi"">Akademi</a>
            <a class=""p-2 text-muted"" href=""/courses/finans"">Finans</a>
            <a class=""p-2 text-muted"" href=""/courses/fotograf"">Fotoğraf</a>
            <a class=""p-2 text-muted"" href=""/courses/isletme"">İşletme</a>
            <a class=""p-2 text-muted"" href=""/courses/pazarlama"">Pazarlama</a>
            <a class=""p-2 text-muted"" href=""/courses/kisisel-gelisim"">Kişisel Gelişim</a>
            <a class=""p-2 text-muted"" href=""/courses/tasarim"">Tasarım</a>
            <a class=""p-2 text-muted"" href=""/courses/bt"">BT</a>
            <a class=""p-2 text-muted"" href");
            WriteLiteral("=\"/courses/yasam-tarzi\">Yaşam Tarzı</a>\r\n        </nav>\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n\r\n\r\n");
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
