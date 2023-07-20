using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        [HtmlAttributeName("user-name")]
        public string? UserName { get; set; }

        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (UserName is null)
            {
                output.Content.SetContent("No Role");
                return;
            }

            IdentityUser user = await _userManager.FindByNameAsync(UserName);
            if (user is null)
            {
                output.Content.SetContent("Could not find user");
                return;
            }

            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            if (allRoles.Count == 0)
            {
                output.Content.SetContent("No Role");
                return;
            }

            TagBuilder mainDiv = new TagBuilder("div");
            foreach (var role in allRoles)
            {
                var hasRole = await _userManager.IsInRoleAsync(user, role);

                var checkbox = new TagBuilder("input");
                checkbox.AddCssClass("form-check-input");
                checkbox.Attributes.Add("type", "checkbox");
                checkbox.Attributes.Add("value", role);
                checkbox.Attributes.Add("disabled", "disabled");
                if (hasRole)
                {
                    checkbox.Attributes.Add("checked", "checked");
                }
                var label = new TagBuilder("label");
                label.AddCssClass("form-check-label");
                label.InnerHtml.Append(role);
                var div = new TagBuilder("div");
                div.AddCssClass("form-check");
                div.InnerHtml.AppendHtml(checkbox);
                div.InnerHtml.AppendHtml(label);
                mainDiv.InnerHtml.AppendHtml(div);
            }
            output.Content.AppendHtml(mainDiv);
        }
    }

}
