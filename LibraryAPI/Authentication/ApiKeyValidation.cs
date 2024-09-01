namespace LibraryAPI.Authentication
{
    /// <summary>
    /// ApiKeyValidation class
    /// </summary>
    public class ApiKeyValidation : IApiKeyValidation
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        public ApiKeyValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Check if Api key is valid or not
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public bool IsApiKeyValid(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                return false;

            string? key = _configuration.GetValue<string>(ApiKeyConstants.ApiKeyName);

            if (key == null || key != apiKey)
                return false;

            return true;
        }
    }
}
