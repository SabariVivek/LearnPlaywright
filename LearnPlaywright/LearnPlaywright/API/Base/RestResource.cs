using Microsoft.Playwright;

namespace LearnPlaywright.API.Base
{
    public class RestResource : PlaywrightFixture
    {
        public static async Task<IAPIResponse> PostMethodAsync<T>(string EndPoint, T inputObject) where T : class
        {
            var response = await
                CreateAsync().Result.
                PostAsync(EndPoint, new APIRequestContextOptions
                {
                    DataObject = inputObject
                });
            return response;
        }

        public static async Task<IAPIResponse> PostMethodAsync<T>(T inputObject) where T : class
        {
            var response = await
                CreateAsync().Result.
                PostAsync("", new APIRequestContextOptions
                {
                    DataObject = inputObject
                });
            return response;
        }

        public static async Task<IAPIResponse> GetMethodAsync<T>(string EndPoint, T inputObject) where T : Dictionary<string, object>
        {
            var response = await
                CreateAsync().Result.
                GetAsync(EndPoint, new APIRequestContextOptions
                {
                    Params = inputObject
                });
            return response;
        }

        public static async Task<IAPIResponse> GetMethodAsync(string EndPoint)
        {
            var response = await
                CreateAsync().Result.
                GetAsync(EndPoint);
            return response;
        }

        public static async Task<IAPIResponse> GetMethodAsync<T>(T inputObject)
        {
            var response = await
                CreateAsync().Result.
                GetAsync("", new APIRequestContextOptions
                {
                    DataObject = inputObject
                });
            return response;
        }
    }
}