using System;
using System.Text.Json;

namespace WeatherApp
{
    
    internal class UserApiManager
    {
        private TextMessages textMessages;
        private FileWorker<UserApi> fileWorker;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApiManager"/> class.
        /// </summary>
        public UserApiManager()
        {            
            textMessages = new TextMessages();
            fileWorker= new FileWorker<UserApi>();
            UserApiList = new List<UserApi>();

        }

        /// <summary>
        ///A collection for storing API keys, suitable for commercial use and capable of storing multiple keys.
        ///This collection allows for selecting the necessary key during runtime.
        /// </summary>
        internal List<UserApi> UserApiList { get; private set; }
        /// <summary>
        /// Write the user key to the local storage
        /// </summary>
        /// <param name="newUserAPi">Full new actual key for connecting to "accuweather.com" servers </param>
        public async Task WriteUserApiToStorageAsync(string newUserAPi)
        {
            try
            {
                UserApiList.Add(new UserApi(newUserAPi));
                await fileWorker.WriteFileToLocalStorageAsync(UserApiList, textMessages.ApiKeysFileName);
            }
            catch(NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return;
            }
            catch(JsonException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ApiFileDoesntExist);
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        /// <summary>
        /// Read all keys from local storage and insert them into the "UserApiList" collection.
        /// </summary>
        public async Task ReadUserApiFromLocalStorageAsync()
        {
            try
            {
                UserApiList = await fileWorker.ReadFileFromLocalStorageAsync(textMessages.ApiKeysFileName); 
            }
            catch(JsonException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ApiFileDoesntExist);
                await Console.Out.WriteLineAsync(ex.Message);
                
            }
            catch (FileNotFoundException ex)
            {
                await Console.Out.WriteLineAsync(textMessages.ApiIsEmpty);
                await Console.Out.WriteLineAsync(ex.Message);
                        }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        
    }

}

