using System.Text.Json;

namespace LearnPlaywright.API.Base
{
    public class HelperClass
    {
        public static object ExtractJsonData(string ApiResponse, string Data)
        {
            var jsonDocument = JsonDocument.Parse(ApiResponse);
            var jsonData = jsonDocument.RootElement.GetProperty(Data);
            return jsonData;
        }

        public static string JSONReader(string FilePath)
        {
            string JsonFilePath = FilePath;
            return File.ReadAllText(JsonFilePath);
        }
    }
}