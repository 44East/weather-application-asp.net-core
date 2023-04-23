using System.Reflection.Metadata;
using System.Text.Json;

namespace WeatherApp
{
    /// <summary>
    ///Generic type for reading, writing, and creating files
    ///This type can handle different types of input/output operations.
    /// </summary>
    /// <typeparam name="T">This type can be used with any JSON-based data storage.</typeparam>
    internal class FileWorker<T> where T : class
    {
        /// <summary>
        ///Read files from local storage by filename
        ///This type allows for reading files from local storage, taking the filename as a parameter.
        /// </summary>
        /// <param name="fileName">Name of the file in a local drive</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="T"/> collection of user data</returns>
        public async Task<List<T>> ReadFileFromLocalStorageAsync(string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                using StreamReader sr = fileInfo.OpenText();
                var prepareString = await sr.ReadToEndAsync();

                return JsonSerializer.Deserialize<List<T>>(prepareString);
            }
            catch(FileNotFoundException ex)
            {
                await CreateFileAsync(fileName);
                throw;
            }
        }
        /// <summary>
        ///Creates a new file if it doesn't exist
        /// </summary>
        /// <param name="fileName">Name of the file in a local drive</param>
        /// <returns>A <see cref="Task"/>  representing the asynchronous operation.</returns>
        private async Task CreateFileAsync(string fileName)
        {
            int bufferSize = 2 << 11;//4096 bytes, it's default buffer size in FileStream.
            await using var fs = new FileStream(fileName, 
                                                FileMode.Create, 
                                                FileAccess.Write, 
                                                FileShare.None, 
                                                bufferSize, 
                                                FileOptions.Asynchronous);                                                
        }
        /// <summary>
        ///Write a collection to local storage using the provided filename.
        ///Before writing, it checks file on existing and if the file doesn't exist, it can create file
        /// </summary>
        /// <param name="currList">Collection of current keys during runtime.</param>
        /// <param name="fileName">Name of the file in a local drive</param>
        /// <returns>A <see cref="Task"/>  representing the asynchronous operation.</returns>
        public async Task WriteFileToLocalStorageAsync(List<T> currList, string fileName)
        {
            if (!File.Exists(fileName))
            {
                await CreateFileAsync(fileName);
            }
            FileInfo fileInfo = new FileInfo(fileName);
            await using FileStream fs = fileInfo.OpenWrite();
            JsonSerializer.Serialize(fs, currList);
        }
        
        

    }
}
