

namespace WeatherApp
{
    /// <summary>
    /// An instance for API keys, with one instance for each API.
    /// </summary>
    internal class UserApi
    {
        /// <summary>
        /// Initializes a new instance of the UserApi class.
        /// </summary>
        public UserApi() { }
        /// <summary>
        /// Initializes a new instance of the UserApi class with a specified API key.
        /// </summary>
        /// <param name="userApi">The API key for the user.</param>
        public UserApi(string userApi) => UserApiProperty = userApi;
        /// <summary>
        /// Gets or sets the API key for the user.
        /// </summary>
        public string UserApiProperty { get; set; }
    }
}
