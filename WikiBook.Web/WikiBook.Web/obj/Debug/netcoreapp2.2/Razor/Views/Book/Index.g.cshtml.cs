#pragma checksum "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\Book\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c02336336e226661584bb068bdebccefa4f9e8eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_Index), @"mvc.1.0.view", @"/Views/Book/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Book/Index.cshtml", typeof(AspNetCore.Views_Book_Index))]
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
#line 1 "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\_ViewImports.cshtml"
using WikiBook.Web;

#line default
#line hidden
#line 2 "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\_ViewImports.cshtml"
using WikiBook.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c02336336e226661584bb068bdebccefa4f9e8eb", @"/Views/Book/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82d2a8d563cfa234e4527ad87ac286b5bba387e1", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WikiBook.Web.Models.BookModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\Book\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(94, 35, true);
            WriteLiteral("\r\n<h2>List of Book</h2>\r\n\r\n\r\n<ol>\r\n");
            EndContext();
#line 11 "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\Book\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(170, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(183, 122, false);
#line 13 "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\Book\Index.cshtml"
       Write(string.Format("{0} -{1} -{2} -{3}", item.BookId.ToString(), item.Title, item.Authors, item.AverageRating.ToString("0.00")));

#line default
#line hidden
            EndContext();
            BeginContext(305, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 14 "C:\Users\hle\Documents\WikiBook\WikiBook.Web\WikiBook.Web\Views\Book\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(319, 7, true);
            WriteLiteral("</ol>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WikiBook.Web.Models.BookModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
