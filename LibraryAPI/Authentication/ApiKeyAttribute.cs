using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Authentication
{
    /// <summary>
    /// ApiKey custom attribute for ApiKey authentication
    /// </summary>
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
