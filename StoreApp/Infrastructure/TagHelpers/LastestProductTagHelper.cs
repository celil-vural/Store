using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contract;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "lastest-product")]
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IProductService _productService;

        [HtmlAttributeName("lastest-product")]
        public int? Count { get; set; } = 5;
        public LastestProductTagHelper(IProductService productService)
        {
            _productService = productService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "my-3");
            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");
            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class", "fa fa-box text-secondary");
            TagBuilder ul = new TagBuilder("ul");
            var products = _productService.GetLastestProducts(Count ?? 5, false);
            foreach (var product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/product/get/{product.ProductId}");
                a.Attributes.Add("class", "text-decoration-none text-reset pointer-events-none");
                a.InnerHtml.AppendHtml(product.ProductName);
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }
            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml(" Lastest Products");
            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);
        }
    }
}
