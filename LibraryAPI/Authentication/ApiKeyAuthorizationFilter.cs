using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryAPI.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IApiKeyValidation _apiKeyValidation;

        /// <summary>
        /// ApiKey custom autherization filter for ApiKey authentication
        /// </summary>
        /// <param name="apiKeyValidation"></param>
        public ApiKeyAuthorizationFilter(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }

        /// <summary>
        /// OnAuthorization
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userApiKey = context.HttpContext.Request.Headers[ApiKeyConstants.ApiKeyHeaderName].ToString();
            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                context.Result = new BadRequestResult();
                return;
            }
            if (!_apiKeyValidation.IsApiKeyValid(userApiKey))
                context.Result = new UnauthorizedResult();
        }
    }
}
