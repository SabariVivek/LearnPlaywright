using LearnPlaywright.API.Base;
using LearnPlaywright.API.Model;
using LearnPlaywright.API.Payload;

namespace LearnPlaywright.API.Tests
{
    public class PostRequest
    {
        [Test, Order(1)]
        public async Task PostAsync()
        {
            // Post Request...
            var response = await RestResource.PostMethodAsync(CreateBookingPayload.GetCreateBookingPayload());

            // Response Verification...
            var jsonString = await response.JsonAsync();
            CreateBookingModel.bookingid = HelperClass.ExtractJsonData(jsonString.ToString()!, "bookingid").ToString()!;
            await Console.Out.WriteLineAsync(CreateBookingModel.bookingid.ToString());
        }
    }
}