using System;
using System.Text.Json;

namespace AssetManagerApp.BusinessLogic
{
    public class AssetJsonDataManager
    {
        string _fileLocation;

        public AssetJsonDataManager(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public List<Asset> ReadAllUserRecords()
        {
            List<Asset> jsonData;
            using (FileStream reader = new FileStream(_fileLocation, FileMode.Open))
            {
                jsonData = JsonSerializer.Deserialize<List<Asset>>(reader);
            }
            return jsonData;
        }

        public void WriteAllUserRecords(List<Asset> jsonData)
        {
            using (FileStream writer = new FileStream(_fileLocation, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(writer, jsonData);
            }
        }

    }
}

