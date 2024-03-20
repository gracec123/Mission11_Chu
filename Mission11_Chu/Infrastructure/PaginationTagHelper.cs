using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_Chu.Models.ViewModels;

namespace Mission11_Chu.Infrastructure
{
    // Custom tag helper for generating pagination links
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        // Constructor to initialize the tag helper with an IUrlHelperFactory instance
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
            // Initialize PageModel to satisfy non-nullable requirement
            PageModel = new PaginationInfo();
        }

        // ViewContext property to access information about the current view
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PaginationInfo PageModel { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass {  get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        // Method to process the tag helper and generate pagination links
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null) 
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalNumPages; i++) 
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new {pageNum = i});
                    tag.InnerHtml.Append(i.ToString());

                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }


                    result.InnerHtml.AppendHtml(tag);
                 }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
