namespace LibraryAPI.Authentication
{
    /// <summary>
    /// IApiKeyValidation
    /// </summary>
    public interface IApiKeyValidation
    {
        /// <summary>
        /// IsApiKeyValid
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        bool IsApiKeyValid(string apiKey);
    }
}
