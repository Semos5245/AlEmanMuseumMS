using ALEmanMuseum.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Infrastructure.TagHelpers
{
    [HtmlTargetElement("auth", Attributes = "asp-authroles")]
    public class RoleAuthorizationTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor mHttpContextAccessor;
        private readonly UserManager<SystemUser> mUserManager;

        public RoleAuthorizationTagHelper(IHttpContextAccessor httpContextAccessor,
            UserManager<SystemUser> userManager)
        {
            mHttpContextAccessor = httpContextAccessor;
            mUserManager = userManager;
        }

        [HtmlAttributeName("asp-authroles")]
        public string Roles { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var httpContext = mHttpContextAccessor.HttpContext;

            if (httpContext != null && httpContext.User != null)
            {
                var userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                // Check if the user has the specific role
                var user = await mUserManager.FindByIdAsync(userId);

                if (user == null)
                    output.SuppressOutput();

                var userRoles = (await mUserManager.GetRolesAsync(user)).Select(role => role.ToLower()); ;
                var authRoles = Roles.Trim().Split(",");
                var showContent = authRoles.Any(authRole => userRoles.Contains(authRole));

                if (!showContent) output.SuppressOutput();
            }
        }
    }
}
