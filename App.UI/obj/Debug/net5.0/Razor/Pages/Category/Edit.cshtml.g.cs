#pragma checksum "D:\Clients\Protein4All\Code\App.UI\Pages\Category\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6dec76b11537f94c70de2dff5adab9e187b5753"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.Core.Pages.Category.Pages_Category_Edit), @"mvc.1.0.razor-page", @"/Pages/Category/Edit.cshtml")]
namespace App.Core.Pages.Category
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
#line 1 "D:\Clients\Protein4All\Code\App.UI\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Clients\Protein4All\Code\App.UI\Pages\_ViewImports.cshtml"
using App.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Clients\Protein4All\Code\App.UI\Pages\_ViewImports.cshtml"
using App.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6dec76b11537f94c70de2dff5adab9e187b5753", @"/Pages/Category/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a14908ad2fe5fa17e6737b771a79a78f1d357a3e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Category_Edit : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Clients\Protein4All\Code\App.UI\Pages\Category\Edit.cshtml"
  
    Layout = "/Pages/Shared/DashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<html>
<!--<body>
    <div class=""h-100 row align-items-center"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5 class=""text-center"">Edit Product Category</h5>-->
                    <!--<span>Add class of <code>.form-control</code> with <code>&lt;input&gt;</code> tag</span>-->
                <!--</div>
                <div class=""card-block"">
                    <form class=""form-material"" method=""post"">
                        <div class=""form-group form-default"">
                            <input type=""text"" asp-for=""Category.Name"" class=""form-control"" required="""">
                            <span class=""form-bar text-danger"" asp-validation-for=""Category.Name""></span>
                            <label class=""float-label"">Category Name</label>
                        </div>
                        <div class=""form-group form-default"">
                            <input type=""text"" asp-for=""Category.DisplayOrder"" ");
            WriteLiteral(@"class=""form-control"" required="""">
                            <span class=""form-bar text-danger"" asp-validation-for=""Category.DisplayOrder""></span>
                            <label class=""float-label"">Display Order</label>
                        </div>
                        <div class=""form-group form-default"">
                            <div class=""form-check"">
                                <label class=""form-check-label mr-5"" for=""flexCheckChecked"">
                                    Is Active

                                </label>
                                <input class=""form-check-input"" type=""checkbox"" asp-for=""Category.IsActive"" id=""flexCheckChecked"" checked>

                            </div>

                        </div>

                        <div class=""text-right"">
                            <button class=""btn btn-out-dashed waves-effect waves-light btn-primary btn-square"" type=""submit"">Add Category</button>
                        </div>

                ");
            WriteLiteral("    </form>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 49 "D:\Clients\Protein4All\Code\App.UI\Pages\Category\Edit.cshtml"
           await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
            }
            );
            WriteLiteral("\r\n</body>-->\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.UI.Pages.Category.EditModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.UI.Pages.Category.EditModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.UI.Pages.Category.EditModel>)PageContext?.ViewData;
        public App.UI.Pages.Category.EditModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591