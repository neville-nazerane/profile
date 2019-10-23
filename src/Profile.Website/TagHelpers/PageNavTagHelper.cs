using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.Website.TagHelpers
{
    public class PageNavTagHelper : AnchorTagHelper
    {

        public PageNavTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Attributes.TryGetAttribute("href", out var href);

            output.TagName = "a";
            if (href.Value.ToString() == ViewContext.RouteData.Values["Page"].ToString())
            {
                output.Attributes.SetAttribute("class",
                        output.Attributes.SingleOrDefault(
                                        a => a.Name == "class")?.Value + " active");
            }

        }

    }
}
