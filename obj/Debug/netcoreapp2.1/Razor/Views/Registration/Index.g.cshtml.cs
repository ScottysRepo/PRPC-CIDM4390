#pragma checksum "C:\Users\hchoi\Desktop\PRPC\PRPC-CIDM4390-Registration\PRPC-CIDM4390-Registration\Views\Registration\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073a431bd0316c3fabaac0819f531c7d54e2724c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registration_Index), @"mvc.1.0.view", @"/Views/Registration/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Registration/Index.cshtml", typeof(AspNetCore.Views_Registration_Index))]
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
#line 1 "C:\Users\hchoi\Desktop\PRPC\PRPC-CIDM4390-Registration\PRPC-CIDM4390-Registration\Views\_ViewImports.cshtml"
using PRPC_CIDM4390;

#line default
#line hidden
#line 2 "C:\Users\hchoi\Desktop\PRPC\PRPC-CIDM4390-Registration\PRPC-CIDM4390-Registration\Views\_ViewImports.cshtml"
using PRPC_CIDM4390.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"073a431bd0316c3fabaac0819f531c7d54e2724c", @"/Views/Registration/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38378f3dbd3a14da148ee2d7c04cc8cfb656ead8", @"/Views/_ViewImports.cshtml")]
    public class Views_Registration_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PRPC_CIDM4390.Models.Registration>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\hchoi\Desktop\PRPC\PRPC-CIDM4390-Registration\PRPC-CIDM4390-Registration\Views\Registration\Index.cshtml"
  
   ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(97, 1395, true);
            WriteLiteral(@"
<div class=""Registration"">
    <h1>Register</h1>



    <h4>Create a new account</h4>
    <hr />
<ul>
     <div class=""form-group "">
  <div class=""col-xs-3"">
    <label for=""username"">Username</label>
    <input class=""form-control"" id=""username"" type=""text"" placeholder=""Enter Username"">
  </div>


 <div class=""col-xs-3"">
    <label for=""Password"">Password</label>
    <input class=""form-control"" id=""Password"" type=""password"" >
  </div>


 <div class=""col-xs-3"">
    <label for=""ConfirmPassword"">Confirm Password</label>
    <input class=""form-control"" id=""ConfirmPassword"" type=""password"">
  </div>

   <div class=""col-xs-3"">
    <label for=""firstname"">Firstname</label>
    <input class=""form-control"" id=""firstname"" type=""text"">
  </div>

  <div class=""col-xs-3"">
    <label for=""lastname"">Lastname</label>
    <input class=""form-control"" id=""lastname"" type=""text"">
  </div>
    
 <div class=""col-xs-3"">
    <label for=""Email"">Email</label>
    <input class=""form-control"" id=""E");
            WriteLiteral(@"mail"" type=""text"" placeholder=""example@example.com"">
  </div>
  
  <div class=""col-xs-3"">
    <label for=""PhoneNumber"">Phone Number</label>
    <input class=""form-control"" id=""PhoneNumber"" type=""number"" placeholder  = ""000)123-4567"">
  </div>
        
        
        <button type=""submit"" class=""btn btn-primary"">Register</button>

    </ul>
  
   
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PRPC_CIDM4390.Models.Registration>> Html { get; private set; }
    }
}
#pragma warning restore 1591
