using LearnPlaywright.API.Base;
using LearnPlaywright.API.Model;
using LearnPlaywright.API.Payload;

namespace LearnPlaywright.API.Tests
{
    public class GetRequest
    {
        [Test, Order(2)]
        public async Task GetBookingAsync()
        {
            // Get Request...
            var response = await RestResource.GetMethodAsync("/" + CreateBookingModel.bookingid!);

            // Response Verification...
            var responseBody = await response.TextAsync();
            await Console.Out.WriteLineAsync(responseBody.ToString());
        }

        [Test, Order(2)]
        public async Task GetBookingUsingParamsAsync()
        {
            // Get Request...
            var response = await RestResource.GetMethodAsync("", GetBookingPayload.GetBookingQueryParams());

            // Response Verification...
            var responseBody = await response.JsonAsync();
            await Console.Out.WriteLineAsync(responseBody.ToString());
        }
    }
}