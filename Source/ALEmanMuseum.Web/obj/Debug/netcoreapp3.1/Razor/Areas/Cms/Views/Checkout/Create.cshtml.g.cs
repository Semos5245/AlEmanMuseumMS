#pragma checksum "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f03baea6b418b64333a89b3422b9d6b6b1f8781a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cms_Views_Checkout_Create), @"mvc.1.0.view", @"/Areas/Cms/Views/Checkout/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f03baea6b418b64333a89b3422b9d6b6b1f8781a", @"/Areas/Cms/Views/Checkout/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad58f7904eec18a426b70d38e056846fd6cdf1b3", @"/Areas/Cms/Views/_ViewImports.cshtml")]
    public class Areas_Cms_Views_Checkout_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckoutCreationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position: absolute; top: 0; left: 0; margin: 0.3em;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
  
    ViewData["Title"] = Localize["New Checkout"].Value;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12\">\r\n        <div class=\"card\">\r\n            <div class=\"header\">\r\n                <p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f03baea6b418b64333a89b3422b9d6b6b1f8781a5949", async() => {
                WriteLiteral("<i class=\"fa fa-arrow-circle-left fa-2x\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p><br />\r\n                <h2>");
#nullable restore
#line 12 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
               Write(Localize["Checkout Number"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 12 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                             Write(Model.CheckoutNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"body\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-6\">\r\n                        <h2>");
#nullable restore
#line 19 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                       Write(Localize["Items Count"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": <span id=\"totalItemsCount\">0</span></h2>\r\n                    </div>\r\n                    <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-6\">\r\n                        <h2>");
#nullable restore
#line 22 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                       Write(Localize["Total Value"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": <span id=\"totalItemsValue\">0.00</span></h2>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-6\">\r\n                        <label for=\"customerName\">");
#nullable restore
#line 27 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                             Write(Localize["Customer Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</label>\r\n                        <input id=\"customerName\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 1370, "\"", 1410, 1);
#nullable restore
#line 28 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
WriteAttributeValue("", 1384, Localize["Customer name"], 1384, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </div>\r\n                    <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-6\">\r\n                        <label for=\"customerPhone\">");
#nullable restore
#line 31 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                              Write(Localize["Customer Phone"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@":</label>
                        <input id=""customerPhone"" placeholder=""09**********"" />
                    </div>
                </div>
                <table class=""table bg-info"" id=""checkoutItemsTable"">
                    <thead>
                        <tr>
                            <th>");
#nullable restore
#line 38 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                           Write(Localize["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 39 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                           Write(Localize["Quantity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 40 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                           Write(Localize["Price"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 41 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                           Write(Localize["Total"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody style=""color: black; min-height:5rem;"" class=""bg-warning"">
                    </tbody>
                    <tfoot class=""bg-info"">
                        <tr>
                            <td>
                                <label for=""itemsList"" class=""form-label"">");
#nullable restore
#line 50 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                     Write(Localize["Item"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</label>\r\n                                <select id=\"itemsList\" class=\"form-control\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f03baea6b418b64333a89b3422b9d6b6b1f8781a12862", async() => {
#nullable restore
#line 52 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                Write(Localize["Choose an item"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 53 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                     foreach (var item in Model.Items)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f03baea6b418b64333a89b3422b9d6b6b1f8781a14613", async() => {
#nullable restore
#line 55 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                            Write(item.FullName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 56 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </select>\r\n                            </td>\r\n                            <td>\r\n                                <label for=\"newQuantity\" class=\"form-label\">");
#nullable restore
#line 60 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                       Write(Localize["Quantity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@":</label>
                                <input class=""form-control"" type=""number"" required id=""newQuantity"" />
                            </td>
                            <td>
                                <div class=""w-100"">
                                    <label for=""newPrice"" class=""form-label"">");
#nullable restore
#line 65 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                        Write(Localize["Price"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@":</label>
                                    <input class=""form-control"" type=""number"" min=""0"" required pattern=""\d*"" id=""newPrice"" />
                                </div>
                            </td>
                            <td>
                                <button class=""btn btn-info"" id=""addItemBtn"">");
#nullable restore
#line 70 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                        Write(Localize["Add"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
                            </td>
                        </tr>
                    </tfoot>
                </table>

                <div class=""row"">
                    <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-6"">
                        <button class=""btn btn-danger btn-lg"" style=""width: 100%;"" id=""clearBtn"">");
#nullable restore
#line 78 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                                            Write(Localize["Clear"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </div>\r\n                    <div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-6\">\r\n                        <button class=\"btn btn-success btn-lg\" style=\"width: 100%;\" id=\"saveCheckoutBtn\">");
#nullable restore
#line 81 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                                                    Write(Localize["Save Checkout"].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Modals", async() => {
                WriteLiteral(@"
    <div class=""modal fade"" id=""deleteItemModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dialog modal-sm modal-notify modal-danger"" role=""document"">
            <!--Content-->
            <div class=""modal-content text-center"">
                <!--Header-->
                <div class=""modal-header d-flex justify-content-center"">
                    <h3 class=""heading"">");
#nullable restore
#line 98 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                   Write(Localize["Are you sure?"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3>
                </div>
                <input type=""hidden"" id=""deleteItemId"" />
                <!--Body-->
                <div class=""modal-body"">
                    <i class=""fa fa-times fa-4x animated rotateIn""></i>
                </div>
                <!--Footer-->
                <div class=""modal-footer flex-center"">
                    <button id=""deleteBtn"" class=""btn btn-outline-danger"">");
#nullable restore
#line 107 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                     Write(Localize["Yes"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                    <button class=\"btn btn-danger waves-effect\" data-dismiss=\"modal\">");
#nullable restore
#line 108 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                                                                Write(Localize["No"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- #endregion -->\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
    $(function () {
        var table = $('#checkoutItemsTable').DataTable({
            paging: false,
            searching: false,
            ordering: false,
            responsive: true,
            autoWidth: true,
            info: false,
            language: {
                'emptyTable': [],
            }
        });

        var itemsData = [];
        itemsData = ");
#nullable restore
#line 132 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
               Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.Items)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var checkoutItems = [];

        $('#clearBtn').on('click', function () { resetTable(); });
        $(document.body).on('click', '.deleteItem', function () {
            $('#deleteItemId').val($(this).data('itemid'));
            $('#deleteItemModal').modal('toggle');
        });
        $('#itemsList').on('change', function (e) {
            let newItemId = $(this).val();

            if (newItemId == '') {
                resetAddItemSection();
                return;
            }

            // find item from itemsData
            let item = itemsData.find(o => o.Id == newItemId);
            if (!item) { resetAddItemSection(); return; }

            // update quantity and price as needed
            let newQuantityInput = $('#newQuantity');
            newQuantityInput.val(item.Quantity > 0 ? 1 : 0);
            newQuantityInput.attr('title', '");
#nullable restore
#line 155 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                       Write(Localize["Max quantity"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(": \' + item.Quantity);\r\n            newQuantityInput.attr(\'max\', item.Quantity);\r\n\r\n            let newPriceElement = $(\'#newPrice\');\r\n            newPriceElement.val(item.SellingPrice);\r\n            newPriceElement.attr(\'title\', \'");
#nullable restore
#line 160 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                      Write(Localize["Original price"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@": ' + item.OriginalPrice);
        });

        $('#deleteBtn').on('click', function () {
            let itemId = $('#deleteItemId').val();
            let checkoutItem = checkoutItems.find(i => i.itemId == itemId);
            if (!checkoutItem) return;
            let item = itemsData.find(i => i.Id == itemId);
            if (!item) return;

            item.Quantity += checkoutItem.quantity;

            checkoutItems = checkoutItems.filter(i => i.itemId != itemId);
            table.row('#tr' + itemId).remove().draw(false);

            $('#deleteItemModal').modal('toggle');
        });

        $('#addItemBtn').on('click', function () {
            let selectedItemId = $('#itemsList').val();

            if (selectedItemId == '') {
                resetAddItemSection();
                ShowErrorNotification('");
#nullable restore
#line 183 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["An item should be choosen"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                return;\r\n            }\r\n\r\n            let item = itemsData.find(o => o.Id == selectedItemId);\r\n            if (!item) {\r\n                resetAddItemSection();\r\n                ShowErrorNotification(\'");
#nullable restore
#line 190 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["An item should be choosen"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                return;\r\n            }\r\n\r\n            let newQuantity = parseInt($(\'#newQuantity\').val());\r\n            if (newQuantity && newQuantity < 1) {\r\n                ShowErrorNotification(\'");
#nullable restore
#line 196 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["Invlaid quantity"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                return;\r\n            }\r\n\r\n            if (item.quantity < newQuantity) {\r\n                ShowErrorNotification(\'");
#nullable restore
#line 201 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["Not enough quantity"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\')\r\n                return;\r\n            }\r\n\r\n            let newPrice = parseInt($(\'#newPrice\').val());\r\n\r\n            if (newPrice && newPrice < 0) {\r\n                ShowErrorNotification(\'");
#nullable restore
#line 208 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["Invlid price"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
                return;
            }

            // Check if the item already exists
            let existingItem = checkoutItems.find(o => o.itemId == item.Id);
            if (existingItem && existingItem.price != newPrice) {
                ShowErrorNotification('");
#nullable restore
#line 215 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["Item exists with a different price"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"')
                return;
            }

            item.Quantity -= newQuantity;

            if (!existingItem) {
                addRowToTable(item.Id, item.FullName, newQuantity, newPrice);

                checkoutItems.push({
                    itemId: item.Id,
                    quantity: newQuantity,
                    price: newPrice
                });

                resetAddItemSection();
                recalculateTotalItemsCount();
                recalculateTotalItemsValue();
                return;
            }

            existingItem.quantity += newQuantity;

            // Update the existing item quantity at the ui
            $('#quantity' + existingItem.itemId).html(existingItem.quantity);

            resetAddItemSection();
            recalculateTotalItemsCount();
            recalculateTotalItemsValue();
        });

        $('#saveCheckoutBtn').on('click', function () {

            if (checkoutItems.length < 1) {
                ShowErrorNo");
                WriteLiteral("tification(\'");
#nullable restore
#line 249 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["Checkout is empty"].Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                return;\r\n            }\r\n\r\n            if (dataHasErrors()) {\r\n                ShowErrorNotification(\'");
#nullable restore
#line 254 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                  Write(Localize["Erros in entered data"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
                return;
            }

            let data = {
                CustomerName: $('#customerName').val(),
                CustomerPhone: $('#customerPhone').val(),
                CheckoutItems: checkoutItems
            };

            // Send a request to add the data
            $.ajax({
                url: '");
#nullable restore
#line 266 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                 Write(Url.Action("AddCheckout", "Checkout"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                method: 'POST',
                data: data,
                success: function (data) {
                    //setTimeout(function () {
                        
                    //}, 2000);
                    // Show success notification
                    ShowSuccessNotification(""");
#nullable restore
#line 274 "D:\Projects\Mine\C#\ALEmanMuseum\ALEmanMuseum\ALEmanMuseum.Web\Areas\Cms\Views\Checkout\Create.cshtml"
                                        Write(Localize["Checkout has been added successfully!"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""", function () { location.reload(); });
                }
            }).fail(function (e) {
                ShowErrorNotification(e.responseText);
            });
        });

        function addRowToTable(itemId, itemName, quantity, price) {
            let tr = document.createElement('tr');
            tr.setAttribute('id', 'tr' + itemId);

            let nameTd = document.createElement('td');
            nameTd.innerHTML = itemName;

            let quantityTd = document.createElement('td');
            quantityTd.setAttribute('id', 'quantity' + itemId);
            quantityTd.innerHTML = quantity;

            let priceTd = document.createElement('td');
            priceTd.setAttribute('id', 'price' + itemId);
            priceTd.innerHTML = price;

            let totalTd = document.createElement('td');
            totalTd.setAttribute('id', 'total' + itemId);
            totalTd.innerHTML = quantity * price;

            let actionsTd = document.createElement('td');
       ");
                WriteLiteral(@"     let deleteATag = document.createElement('a');
            deleteATag.setAttribute('href', 'javascript:void(0)');
            deleteATag.setAttribute('data-itemid', itemId);

            deleteATag.classList.add('deleteItem');

            let iDeleteTag = document.createElement('i');
            iDeleteTag.setAttribute('class', 'fa fa-trash');
            deleteATag.appendChild(iDeleteTag);

            actionsTd.appendChild(deleteATag);

            tr.appendChild(nameTd)
            tr.appendChild(quantityTd);
            tr.appendChild(priceTd);
            tr.appendChild(totalTd);
            tr.appendChild(actionsTd);

            $('#checkoutItemsTable').find('tbody')[0].appendChild(tr);
        }

        function recalculateTotalItemsCount() {
            let newCount = checkoutItems.reduce(function (previousValue, currentValue) {
                return previousValue + currentValue['quantity'];
            },0);

            $('#totalItemsCount').html(newCount);
       ");
                WriteLiteral(@" }

        function recalculateTotalItemsValue() {
            let newValue = checkoutItems.reduce(function (previousValue, currentValue) {
                return previousValue + (currentValue['quantity'] * currentValue['price']);
            }, 0);
            $('#totalItemsValue').html(newValue);
        }

        function resetTable() {

            checkoutItems.forEach(o => {
                let item = itemsData.find(i => i.Id == o.itemId);
                if (item) item.Quantity += o.quantity;

                table.row('#tr' + o.itemId).remove().draw(false);
            });

            checkoutItems = [];
            resetAddItemSection();
            recalculateTotalItemsCount();
            recalculateTotalItemsValue();
        }

        function resetAddItemSection() {
            $('#itemsList').val('');
            let newQuantityInput = $('#newQuantity');
            newQuantityInput.val(0);
            newQuantityInput.attr('title', '');
            newQuantityIn");
                WriteLiteral(@"put.removeAttr('max');

            let newPriceElement = $('#newPrice');
            newPriceElement.val(0.00);
            newPriceElement.attr('title', '');
        }

        function dataHasErrors() {
            // Check if a item has a negative quantity
            let gotErrors = false;

            // Check quantity only for now
            itemsData.forEach(i => {
                if (i.Quantity < 0) { return true; }
            });

            return gotErrors;
        }
    });
    </script>
");
            }
            );
            WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckoutCreationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591