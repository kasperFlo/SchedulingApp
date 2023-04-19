namespace AssetManagerApp.DataAccess;

using System.Text.Json;
using BusinessLogic;

public class AssetsJsonManager : ContentPage
{
    public class UserJsonDataManager
    {
        string _fileLocation;

        public UserJsonDataManager(string fileLocation)
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
