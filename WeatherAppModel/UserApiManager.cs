using System.Text.Json;

namespace WeatherApp
{
    internal class UserApiManager
    {
        private TextMessages textMessages;
        private FileWorker<UserApi> fileWorker;
        public UserApiManager()
        {            
            textMessages = new TextMessages();
            fileWorker= new FileWorker<UserApi>();
            UserApiList = new List<UserApi>();

        }

        /// <summary>
        /// Коллекция для хранения API ключей, коллекция подходит при использовании коммерческого доступа и хранении нескольких ключей, 
        /// соотсветсвенно можно реализовать необходимый выбор при запуске. 
        /// </summary>
        internal List<UserApi> UserApiList { get; private set; }
        /// <summary>
        /// Метод записывает API ключи в файл.
        /// </summary>
        /// <param name="formalUserAPi"></param>
        public async Task WriteUserApiToLocalStorageAsync(string formalUserAPi)
        {
            try
            {
                if (string.IsNullOrEmpty(formalUserAPi))
                    throw new NullReferenceException(textMessages.IncorrectInput);

                UserApiList.Add(new UserApi(formalUserAPi));
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
        /// При запуске всегда проверяется наличие файла ключей и читается информация из него,
        /// если файл не создан или отсутствует, выводится соответствующее сообщение и экземпляр файлового обработчика создает пустой файл 
        /// и пробрасывает соответствующее исключение.
        /// </summary>
        public async Task ReadUserApiFromLocalStorageAsync()
        {
            try
            {
                UserApiList = await fileWorker.ReadFileFromLocalDiskAsync(textMessages.ApiKeysFileName); 
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

