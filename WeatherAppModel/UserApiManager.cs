using System.Text.Json;

namespace WeatherApp
{
    public class UserApiManager
    {
        private TextMessages textMessages;
        private FileWorker<UserApi> fileWorker;
        public UserApiManager(TextMessages textMessages)
        {            
            this.textMessages = textMessages;
            fileWorker= new FileWorker<UserApi>();
            UserApiList = new List<UserApi>();
        }

        /// <summary>
        /// Коллекция для хранения API ключей, коллекция подходит при использовании коммерческого доступа и хранении нескольких ключей, 
        /// соотсветсвенно можно реализовать необходимый выбор при запуске. 
        /// </summary>
        private List<UserApi> UserApiList;
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
        /// Возвращает первый доступный ключ из коллекции если коллекция пуста, возвращает null.
        /// Полностью инкапсулирует коллекцию.
        /// </summary>
        /// <returns></returns>
        public string GetTheFirstKey()
        {
            return UserApiList?.FirstOrDefault()?.UserApiProperty ?? null;
        }
        /// <summary>
        /// При запуске всегда проверяется наличие файла ключей и читается информация из него,
        /// если файл не создан или отсутствует, выводится соответствующее сообщение и экземпляр файлового обработчика создает пустой файл 
        /// и пробрасывает соответствующее исключение.
        /// </summary>
        public void ReadUserApiFromLocalStorage()
        {
            try
            {
                UserApiList = fileWorker.ReadFileFromLocalDisk(textMessages.ApiKeysFileName); 
            }
            catch(JsonException ex)
            {
                Console.Out.WriteLineAsync(textMessages.ApiFileDoesntExist);
                Console.Out.WriteLineAsync(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.Out.WriteLineAsync(textMessages.ApiIsEmpty);
                Console.Out.WriteLineAsync(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLineAsync(ex.Message);
            }
        }
        
    }

}

