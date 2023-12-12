namespace LearnPlaywright.API.Payload
{
    public class GetBookingPayload
    {
        public static Dictionary<string, object> GetBookingQueryParams()
        {
            var queryParams = new Dictionary<string, object>
            {
                { "firstname", Payload.CreateBookingPayload.GetCreateBookingPayload().firstname! },
                { "lastname", Payload.CreateBookingPayload.GetCreateBookingPayload().lastname! }
            };
            return queryParams;
        }
    }
}