#pragma checksum "C:\Users\yellow\source\repos\Helperland\Helperland\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd149a8cc68a18e317649dcbfb40e28f8f357520"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\yellow\source\repos\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yellow\source\repos\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd149a8cc68a18e317649dcbfb40e28f8f357520", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/script.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-current", new global::Microsoft.AspNetCore.Html.HtmlString("page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Prices", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Contact", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "About", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FAQ", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\yellow\source\repos\Helperland\Helperland\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f3575206618", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

    <!-- favicon -->
    <link rel=""apple-touch-icon"" sizes=""180x180"" href=""images/favicon/apple-touch-icon.png"">
    <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""images/favicon/favicon-32x32.png"">
    <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""images/favicon/favicon-16x16.png"">
    <link rel=""manifest"" href=""images/favicon/site.webmanifest"">
    <link rel=""mask-icon"" href=""images/favicon/safari-pinned-tab.svg"" color=""#5bbad5"">
    <meta name=""msapplication-TileColor"" content=""#da532c"">
    <meta name=""theme-color"" content=""#ffffff"">

    <!-- style -->
");
                WriteLiteral("    <link href=\"lib/bootstrap/dist/css/bootstrap.min.css\" rel=\"stylesheet\" />\r\n    <link rel=\"stylesheet\" href=\"css/Home.css\">\r\n\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f3575207961", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script src=\"lib/bootstrap/dist/js/bootstrap.bundle.min.js\"></script>\r\n    <script src=\"lib/jquery/dist/jquery.js/jquery.min.js\"></script>\r\n\r\n");
                WriteLiteral("    <title>Helperland</title>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f3575209992", async() => {
                WriteLiteral(@"
<!-- header -->
<section id=""header"">
    <nav class=""navbar navbar-dark fixed-top navbar-expand-lg"" id=""nav"">
        <div class=""container-fluid"">
            <a class=""navbar-brand me-auto"" href=""#"">
                <img id=""navlogo"" src=""./images/logo-large.png""");
                BeginWriteAttribute("alt", " alt=\"", 2244, "\"", 2250, 0);
                EndWriteAttribute();
                WriteLiteral(@">
            </a>
            <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse""
                data-bs-target=""#navbarNavDropdown"" aria-controls=""navbarNavDropdown"" aria-expanded=""false""
                aria-label=""Toggle navigation"">
                <span class="" navbar-toggler-icon""></span>
            </button>
            <div class=""collapse navbar-collapse"" id=""navbarNavDropdown"">
                <ul class=""navbar-nav d-flex align-items-lg-center justify-content-lg-end justify-content-sm--t"" id=""navw"">
                    <li class=""nav-item"">
                        <a class=""nav-link"" aria-current=""page"" href=""#"">
                            <button type=""button"" class=""btn btn-outline-light"">Book a Cleaner</button>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f35752011618", async() => {
                    WriteLiteral("Prices");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""#"">Our Guarantee</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""#"">Blog</a>
                    </li>
                    <li class=""nav-item"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f35752013608", async() => {
                    WriteLiteral("Contact us");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" aria-current=""page"" href=""#"">
                            <button type=""button"" class=""btn btn-outline-light"">Login</button>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" aria-current=""page"" href=""#"">
                            <button type=""button"" class=""btn btn-outline-light"">Become a Helper</button>
                        </a>
                    </li>

                    <li class=""nav-item dropdown"">
                        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button""
                            data-bs-toggle=""dropdown"" aria-expanded=""false"">
                            <img src=""./images/ic-flag.png"" alt=""ic-flag"">
                        </a>
                        <ul class=""dropdown-menu dropdown-menu-end bg-dark text-light"" aria-labelledb");
                WriteLiteral(@"y=""defaultDropdown"">
                            <li>
                                <a class=""dropdown-item"" data-img=""https://cdn-icons-png.flaticon.com/128/206/206626.png"" href=""#""><img src=""https://cdn-icons-png.flaticon.com/128/206/206626.png"" alt=""flag""> USA</a>
                            </li>
                            <li>
                                <a class=""dropdown-item"" data-img=""https://cdn-icons-png.flaticon.com/128/555/555417.png"" href=""#""><img src=""https://cdn-icons-png.flaticon.com/128/555/555417.png"" alt=""flag""> England</a>
                            </li>

                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</section>


<!-- banner Section  -->
 <section id=""banner"">
   <div class=""banner-container"">
       <h1>Lorem ipsum text</h1>
           <ul>
               <li>Lorem ipsum dolor sit amet, consectetur adipiscing</li>
               <li>Lorem ipsum dolor sit amet, consectetur adipisci");
                WriteLiteral(@"ng</li>
               <li>Lorem ipsum dolor sit amet, consectetur adipiscing</li>
           </ul>
           <div class=""text-center"">
            <button id=""book-cleaner-button"" type=""button"" class=""btn btn-lg btn-outline-light px-4"">Let's Book a
                Cleaner</button>
        </div>
        <div class=""step-wrapper"">
            <div class=""row justify-content-center flex-wrap"">
                <div class=""col-lg-3 col-6 process-item-1 full-width"">
                    <div class=""step"">
                        <span>
                            <img src=""images/step-1.png"" alt=""Enter Postcode"">
                        </span>
                        <p>Enter your postcode</p>
                    </div>
                </div>
                <div class=""col-lg-3 col-6 process-item-2 full-width"">
                    <div class=""step"">
                        <span>
                            <img src=""images/step-2.png"" alt=""Select Plan"">
                        </span>
   ");
                WriteLiteral(@"                     <p>Select your plan</p>
                    </div>
                </div>
                <div class=""col-lg-3 col-6 process-item-3 full-width"">
                    <div class=""step"">
                        <span>
                            <img src=""images/step-3.png"" alt=""Pay Securely"">
                        </span>
                        <p>Pay securely online</p>
                    </div>
                </div>
                <div class=""col-lg-3 col-6 process-item-4 full-width"">
                    <div class=""step"">
                        <span>
                            <img src=""images/step-4.png"" alt=""Amazing service"">
                        </span>
                        <p>Enjoy amazing service</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""scroll-link-wrapper"">
        <a href=""#"" title=""Scroll Down"" class=""scroll-link"">
            <img src=""images/white-down-arrow.png"" alt");
                WriteLiteral(@"=""Scroll-down"">
        </a>
    </div>
</section>

<!-- why helper section-->
<section id=""why-helperhand-section"">
    <div class=""container"">
        <div class=""why-helperland-heading""><h2 class=""text-center"">Why Helperland</h2></div>
        <div class=""row row-cols-auto"">
          <div class=""col-12 col-md-6 col-lg-4 text-center"">
            <div class=""img-block"">
                <img src=""images/group-21.png"" alt=""Professionals"">
            </div>
            <h3  style=""margin-top: 35px;"" class=""justify-content-center d-flex align-items-center"">Experience & Vetted Professionals
            </h3>
            <p style=""margin-top: 25px;"">dominate the industry in scale and scope with an adaptable, extensive network that consistently delivers exceptional results.</p>
          </div>
          <div class=""col-12 col-md-6 col-lg-4 text-center"">
            <div class=""img-block"">
                <img src=""images/group-23.png"" alt=""Online Payment"">
            </div>
            <h");
                WriteLiteral(@"3 style=""margin-top: 55px;"" class=""justify-content-center  d-flex align-items-center"">Secure Online Payment</h3>
            <p style=""margin-top: 45px;"">Payment is processed securely online. Customers pay safely online and manage the booking.</p>
        
          </div>
          <div class=""col-12 col-md-6 col-lg-4 text-center"">
            <div class=""img-block"">
                <img src=""images/group-24.png"" alt=""Customer service"">
            </div>
            <h3 style=""margin-top: 55px;"" class=""justify-content-center  d-flex align-items-center"">Dedicated Customer Service</h3>
            <p style=""margin-top: 45px;"">to our customers and are guided in all we do by their needs. The team is always happy to support you and offer all the information.</p>
        
          </div>
        </div>
      </div>
</section>

<!--blog section-->
<section id=""blog-section"" class=""align-items-center"">
    <div class=""container align-items-center"">
    <div class=""row row-cols-auto justify-conte");
                WriteLiteral(@"nt-center align-items-center"">
        <div class=""col order-2 order-sm-2 order-lg-1"">
            <div class=""blog-title""><h2 class=""h3"">Lorem ipsum dolor sit amet, consectetur</h2></div>
            <div class=""blog-text"">
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nisi sapien, suscipit ut accumsan vitae, pulvinar ac libero.</p>
                <p>Aliquam erat volutpat. Nullam quis ex odio. Nam bibendum cursus purus, vel efficitur urna finibus vitae. Nullam finibus aliquet pharetra. Morbi in sem dolor. Integer pretium hendrerit ante quis vehicula.</p>
                <p>Mauris consequat ornare enim, sed lobortis quam ultrices sed.</p>
            </div>
        </div>
        <div class=""col order-1 order-sm-1 order-lg-2"">
                <img src=""images/group-36.png"" class=""image-block"" alt="" "">
        </div>
    </div>

        <!--our blog-->
        <div class=""row row-cols-auto ourblog justify-content-center"">
            <div class=""col-12 text-");
                WriteLiteral(@"center our-blog-heading"">
                <h2>Our Blog</h2>
            </div>
            <div class=""col card-size"">
                <div class=""card-content"">
                    <div class=""ourblog-img""><img src=""images/group-28.png"" style=""width: 100%;""");
                BeginWriteAttribute("alt", " alt=\"", 11115, "\"", 11121, 0);
                EndWriteAttribute();
                WriteLiteral(@"></div>
                    <div class=""card-description"">
                        <h3>Lorem ipsum dolor sit amet</h3>
                        <div class=""date"">January 28,2019</div>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum metus pulvinar aliquet.</p>
                        <a href=""#"" class=""readmore"">Read the post
                            <img src=""images/shape-2.png"" alt=""right arrow"">
                        </a>
                    </div>
                </div>
            </div>
            <div class=""col card-size"">
                <div class=""card-content"">
                    <div class=""ourblog-img""><img src=""images/group-29.png"" style=""width: 100%;""");
                BeginWriteAttribute("alt", " alt=\"", 11865, "\"", 11871, 0);
                EndWriteAttribute();
                WriteLiteral(@"></div>
                    <div class=""card-description"">
                        <h3>Lorem ipsum dolor sit amet</h3>
                        <div class=""date"">January 28,2019</div>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum metus pulvinar aliquet.</p>
                        <a href=""#"" class=""readmore"">Read the post
                            <img src=""images/shape-2.png"" alt=""right arrow"">
                        </a>
                    </div>
                </div>
            </div>
            <div class=""col card-size"">
                <div class=""card-content"">
                    <div class=""ourblog-img""><img src=""images/group-30.png"" style=""width: 100%;""");
                BeginWriteAttribute("alt", " alt=\"", 12615, "\"", 12621, 0);
                EndWriteAttribute();
                WriteLiteral(@"></div>
                    <div class=""card-description"">
                        <h3>Lorem ipsum dolor sit amet</h3>
                        <div class=""date"">January 28,2019</div>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum metus pulvinar aliquet.</p>
                        <a href=""#"" class=""readmore"">Read the post
                            <img src=""images/shape-2.png"" alt=""right arrow"">
                        </a>
                    </div>
                </div>
            </div>
      </div>
</section>

<!--our coustomer-->
<section id=""our-customer"" class=""align-item-center"">
    <div class=""container"">
        <div class=""our-customer-heading""><h2 class=""text-center"">What Our Customers Say</h2></div>
        <div class=""row row-cols-auto justify-content-evenly align-items-center"">
            <div class=""col customer-card"">
                    <div class=""d-flex flex-row customer-info"">
                        <div class");
                WriteLiteral("=\"customer-img\">\r\n                            <img src=\"images/group-31.png\"");
                BeginWriteAttribute("alt", " alt=\"", 13722, "\"", 13728, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                        <div class=""customer-textbox"">
                            <h2>Lary Watson</h2>
                            <p>Manchester</p>
                        </div>
                    </div>
                    <div class=""customer-detail"">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum metus pulvinar aliquet consequat. Praesent nec malesuada nibh.</p>
                        <p>Nullam et metus congue, auctor augue sit amet, consectetur tortor.</p>
                        <a href=""#"" class=""readmore"">Read the post
                            <img src=""images/shape-2.png"" alt=""right arrow"">
                        </a>
                    </div>
            </div>
            <div class=""col customer-card"">    
                    <div class=""d-flex flex-row customer-info"">
                        <div class=""customer-img"">
                            <img src=""images/group-32.png""");
                BeginWriteAttribute("alt", " alt=\"", 14741, "\"", 14747, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                        <div class=""customer-textbox"">
                            <h2>John Smith</h2>
                            <p>Manchester</p>
                        </div>
                    </div>
                    <div class=""customer-detail"">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum metus pulvinar aliquet consequat. Praesent nec malesuada nibh.</p>
                        <p>Nullam et metus congue, auctor augue sit amet, consectetur tortor.</p>
                        <a href=""#"" class=""readmore"">Read the post
                            <img src=""images/shape-2.png"" alt=""right arrow"">
                        </a>
                    </div>
            </div>
            <div class=""col customer-card"">
                    <div class=""d-flex flex-row customer-info"">
                        <div class=""customer-img"">
                            <img src=""images/group-33.png""");
                BeginWriteAttribute("alt", " alt=\"", 15755, "\"", 15761, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                        <div class=""customer-textbox"">
                            <h2>Lars Johnson</h2>
                            <p>Manchester</p>
                        </div>
                    </div>
                    <div class=""customer-detail"">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum metus pulvinar aliquet consequat. Praesent nec malesuada nibh.</p>
                        <p>Nullam et metus congue, auctor augue sit amet, consectetur tortor.</p>
                        <a href=""#"" class=""readmore"">Read the post
                            <img src=""images/shape-2.png"" alt=""right arrow"">
                        </a>
                    </div>
            </div>
        </div>
    </div>
</section>

<!--Get Our NewsLetter-->
<section class=""our-news-letter"">
    <div class=""newsletter-container text-center"">
        <a href=""#"" class=""scroll-top""><img src=""images/forma-1.png"" alt=""up-ar");
                WriteLiteral(@"row""></a>
        <a href=""#"" class=""message-boat""><img src=""images/layer-598.png"" alt=""message-boat""></a>
        <h2>GET OUR NEWSLETTER</h2>
        <div class=""form-row d-flex justify-content-center align-items-center"">
            <div class=""form-group"">
                <label for=""email"" style=""display: none;"">YOUR EMAIL</label>
                <input type=""text"" placeholder=""YOUR EMAIL"" id=""email"" class=""form-control"">
            </div>
            <div class=""btn-wrapper"">
                <button class=""red-btn"">Submit</button>
            </div>
        </div>
    </div>
</section>

<!--footer -->
<section id=""footer"" class=""d-flex flex-column flex-md-row justify-content-around align-items-center"">
        <img src=""./images/footer-logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 17564, "\"", 17570, 0);
                EndWriteAttribute();
                WriteLiteral(" width=\"120\" height=\"92\">\r\n        <ul class=\"d-flex flex-column flex-md-row text-uppercase footer-list\">\r\n            <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f35752030886", async() => {
                    WriteLiteral("home");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n            <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f35752032339", async() => {
                    WriteLiteral("About");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n            <li><a>testimonials</a></li>\r\n            <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd149a8cc68a18e317649dcbfb40e28f8f35752033837", async() => {
                    WriteLiteral("faqs");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n            <li><a>insurance policy</a></li>\r\n            <li><a>impressum</a></li>\r\n        </ul>\r\n        <div class=\"px-4 d-flex footer-social-media\">\r\n                <div><img src=\"./images/ic-facebook.png\" width=\"9\" height=\"18\"");
                BeginWriteAttribute("alt", " alt=\"", 18177, "\"", 18183, 0);
                EndWriteAttribute();
                WriteLiteral("></div>\r\n                <div><img src=\"./images/ic-instagram.png\" width=\"20\" height=\"20\"");
                BeginWriteAttribute("alt", " alt=\"", 18273, "\"", 18279, 0);
                EndWriteAttribute();
                WriteLiteral(@"></div>
        </div>
</section>

<section id=""homepage-bottom"">
    <div class=""d-flex justify-content-center align-items-md-center w-100 privacy-policy"">
        <p class=policy-msg>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut feugiat nunc libero, ac malesuada ligula aliquam
            ac. <a href=""#"" style=""text-decoration: none;"">Privacy Policy</a> </p>
        <button id=""policy-button"">OK!</button>
    </div>
</section> 
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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