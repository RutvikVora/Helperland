using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Helperland_Clone.Services
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string GetUserName()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.Name);
        }

        public string GetUserTypeId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.GivenName);
        }

        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
