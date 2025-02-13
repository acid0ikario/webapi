using Microsoft.AspNetCore.Authorization;

namespace MyProject.Api.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute()
        {
            // Custom logic if needed
        }
    }
}