using System.IO;
using AppBarLib.Models;
using Newtonsoft.Json;

namespace AppBarLib.Services
{
    internal class SaveLoadService
    {
        private readonly string _saveFolderPath;
        private const string SaveFileName = "appbar.json";

        private string SaveFilePath => Path.Combine(_saveFolderPath, SaveFileName);

        public SaveLoadService(string saveFolderPath)
        {
            _saveFolderPath = saveFolderPath;
        }

        public AppBarData Load()
        {
            if (!File.Exists(SaveFilePath))
            {
                return new AppBarData();
            }

            var json = File.ReadAllText(SaveFilePath);
            return JsonConvert.DeserializeObject<AppBarData>(json);
        }

        public void Save(AppBarData data)
        {
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(SaveFileName, json);
        }
    }
}