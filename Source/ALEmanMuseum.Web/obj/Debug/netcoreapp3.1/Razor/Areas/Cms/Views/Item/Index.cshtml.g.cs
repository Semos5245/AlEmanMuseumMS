#pragma checksum "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff6e49f5a9cc91f8ff3e6954ebc813233df625fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cms_Views_Item_Index), @"mvc.1.0.view", @"/Areas/Cms/Views/Item/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff6e49f5a9cc91f8ff3e6954ebc813233df625fe", @"/Areas/Cms/Views/Item/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad58f7904eec18a426b70d38e056846fd6cdf1b3", @"/Areas/Cms/Views/_ViewImports.cshtml")]
    public class Areas_Cms_Views_Item_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Item>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
  
    ViewData["Title"] = Localizer["Items"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"block-header\">\r\n    <h2>\r\n        ");
#nullable restore
#line 12 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
   Write(Localizer["Items"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h2>\r\n</div>\r\n\r\n<!-- #region Items Table-->\r\n<div class=\"row clearfix\">\r\n    <div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12\">\r\n        <div class=\"card\">\r\n            <div class=\"header\">\r\n                <h2>\r\n                    ");
#nullable restore
#line 22 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
               Write(Localizer["Items"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </h2>
                <ul class=""header-dropdown m-r--5"">
                    <li class=""dropdown"">
                        <a href=""javascript:void(0);"" class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-haspopup=""true"" aria-expanded=""false"">
                            <i class=""material-icons"">more_vert</i>
                        </a>
                        <ul class=""dropdown-menu pull-right"">
                            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff6e49f5a9cc91f8ff3e6954ebc813233df625fe6561", async() => {
#nullable restore
#line 30 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                                                        Write(Localizer["Add Item"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class=""body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-striped table-hover"" id=""itemsTable"">
                        <thead>
                            <tr>
                                <th>");
#nullable restore
#line 40 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                               Write(Localizer["Unique Number"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 41 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                               Write(Localizer["Arabic name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 42 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                               Write(Localizer["English name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 43 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                               Write(Localizer["Added Date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 44 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                               Write(Localizer["Quantity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 45 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                               Write(Localizer["Selling Price"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 50 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                             foreach (var item in Model)
                            {
                                var trId = "tr" + item.Id;


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("id", " id=\"", 2088, "\"", 2098, 1);
#nullable restore
#line 54 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
WriteAttributeValue("", 2093, trId, 2093, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <td>");
#nullable restore
#line 55 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(item.UniqueNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 56 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(item.ArabicName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 57 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(item.EnglishName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 58 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(item.CreatedDate.ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 59 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 60 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(item.SellingPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 60 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                                      Write(Localizer["S.P"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff6e49f5a9cc91f8ff3e6954ebc813233df625fe13658", async() => {
                WriteLiteral("<i class=\"fa fa-info\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        <a href=\"javascript:void(0)\" class=\"deleteItem\" data-itemid=\"");
#nullable restore
#line 63 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                                                                                Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">&nbsp;<i class=\"fa fa-trash\"></i></a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 66 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- #endregion -->\r\n\r\n");
            DefineSection("Modals", async() => {
                WriteLiteral(@"
   

    <!-- Delete modal -->
    <div class=""modal fade"" id=""deleteImageModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dialog modal-sm modal-notify modal-danger"" role=""document"">
            <!--Content-->
            <div class=""modal-content text-center"">
                <!--Header-->
                <div class=""modal-header d-flex justify-content-center"">
                    <h3 class=""heading"">");
#nullable restore
#line 87 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                   Write(Localizer["Are you sure?"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                </div>\r\n                <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3731, "\"", 3739, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""deleteItemId"" />
                <!--Body-->
                <div class=""modal-body"">

                    <i class=""fa fa-times fa-4x animated rotateIn""></i>

                </div>

                <!--Footer-->
                <div class=""modal-footer flex-center"">
                    <button id=""deleteBtn"" class=""btn btn-outline-danger"">");
#nullable restore
#line 99 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                                                     Write(Localizer["Yes"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                    <button class=\"btn btn-danger waves-effect\" data-dismiss=\"modal\">");
#nullable restore
#line 100 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                                                                Write(Localizer["No"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- #endregion -->\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n\r\n            $(\"#itemsTable\").DataTable({\r\n                \"processing\": true,\r\n                \"bServerSide\": true,\r\n                \"sAjaxSource\": \'");
#nullable restore
#line 115 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                           Write(Url.Action("ItemsByPageAndSearch", "Item"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                ""sServerMethod"": 'GET',
                ""aoColumns"": [
                    { data: 'uniqueNumber', 'orderable': true},
                    { data: 'arabicName', 'orderable': true},
                    { data: 'englishName', 'orderable': true},
                    { data: 'createdDate', 'orderable': true},
                    { data: 'quantity', 'orderable': true},
                    { data: 'sellingPrice', 'orderable': true },
                    {
                        data: function (o) {
                            return ""<a href='");
#nullable restore
#line 126 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                        Write(Url.Action("Edit", "Item"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + o.id + ""'><i class='fa fa-edit'></i></a>"" +
                                        ""<a href='javascript:void(0)' class='deleteItem' data-itemid='"" + o.id + ""'>&nbsp;<i class='fa fa-trash'></i></a>"";
                        }
                    }
                ]
            });

            var deleteModal = $(""#deleteItemModal"");
            var deleteItemIdElement = $(""#deleteItemId"");

             // Subscribe to all buttons that delete rows
             $(""#itemsTable"").on('click', '.deleteItem', function () {
                // Fill the id in the modal
                deleteItemIdElement.val($(this).data(""itemid""));

                // Open the modal
                deleteModal.modal(""toggle"");
             });

             $(""#deleteBtn"").on(""click"", function () {
                DeleteSlider(deleteItemIdElement.val());
             });

             // Deletes a Slider
            function DeleteSlider(id) {
                // Send request
                $.ajax({
 ");
                WriteLiteral("                   type: \"POST\",\r\n                    url: \"");
#nullable restore
#line 154 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                     Write(Url.Action("Delete", "Item"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/"" + id,
                    success: function () {
                        // Remove the row and re-apply the magic to the table
                        $(""#itemsTable"").DataTable().row('#tr' + id).remove().draw(false);

                        // Close the modal
                        deleteModal.modal(""toggle"");

                        // Show success message
                        ShowSuccessNotification(""");
#nullable restore
#line 163 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Item\Index.cshtml"
                                            Write(Localizer["Item has been deleted successfully!"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""");
                        ClearModals();
                    }
                }).fail(function (e) {
                    // Show error message
                    ShowErrorNotification(e.responseText);
                });
            }
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
