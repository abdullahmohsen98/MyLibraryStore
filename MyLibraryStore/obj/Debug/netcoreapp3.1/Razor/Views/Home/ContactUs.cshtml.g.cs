#pragma checksum "C:\Users\Darsh\Downloads\MyProject2\MyLibraryStore\MyLibraryStore\Views\Home\ContactUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50e7899d1db705b9942daa9aca13939e03e5e083"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ContactUs), @"mvc.1.0.view", @"/Views/Home/ContactUs.cshtml")]
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
#line 1 "C:\Users\Darsh\Downloads\MyProject2\MyLibraryStore\MyLibraryStore\Views\_ViewImports.cshtml"
using MyLibraryStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50e7899d1db705b9942daa9aca13939e03e5e083", @"/Views/Home/ContactUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc56314188e2081fc1a9b05f2e04168de11a8889", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ContactUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\Darsh\Downloads\MyProject2\MyLibraryStore\MyLibraryStore\Views\Home\ContactUs.cshtml"
  
    ViewData["Title"] = "Contact us";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container contact"">
    <div class=""row"" >
        <div class=""col-md-3 bg-success"" style=""border-radius:10px; margin-bottom:8px"">
            <div class=""contact-info"">
                <img src=""https://image.ibb.co/kUASdV/contact-image.png"" alt=""image"" />
                <h2>Contact Us : </h2> <hr /> <br /><br /><br />
                <h4 style=""font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif"">We would love to hear from you !</h4>
            </div>
        </div>
        <div class=""col-md-9"">
            <div class=""contact-form"">
                <div class=""form-group"">
                    <label class=""control-label col-sm-2"" for=""fname"">First Name:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control"" id=""fname"" placeholder=""Enter First Name"" name=""fname"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-l");
            WriteLiteral(@"abel col-sm-2"" for=""lname"">Last Name:</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control"" id=""lname"" placeholder=""Enter Last Name"" name=""lname"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label col-sm-2"" for=""email"">Email:</label>
                    <div class=""col-sm-10"">
                        <input type=""email"" class=""form-control"" id=""email"" placeholder=""Enter email"" name=""email"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label col-sm-2"" for=""comment"" >Comment:</label>
                    <div class=""col-sm-10"">
                        <textarea class=""form-control"" rows=""5"" id=""comment"" placeholder=""Type your Messege ....""></textarea>
                    </div>
                </div>
                <div class=""form-group"">
                   ");
            WriteLiteral(" <div class=\"col-sm-offset-2 col-sm-10\">\r\n                        <button type=\"submit\" class=\"btn btn-warning\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "50e7899d1db705b9942daa9aca13939e03e5e0836070", async() => {
                WriteLiteral("Submit");
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
            WriteLiteral("</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
