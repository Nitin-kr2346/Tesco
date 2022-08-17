using Microsoft.AspNetCore.Http;

namespace Tesco.Helper
{
    public static class AppContext
    {
        private static IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Assign the injected IHttpContextAccessor to local variable
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Assigning the property with HttpContext
        /// </summary>
        public static HttpContext Current => _httpContextAccessor.HttpContext;
    }
}
