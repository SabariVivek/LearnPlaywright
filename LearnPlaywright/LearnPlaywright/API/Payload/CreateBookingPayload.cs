using Faker;

namespace LearnPlaywright.API.Payload
{
    public class CreateBookingPayload
    {
        public static BookingPayload GetCreateBookingPayload()
        {
            var bookingPayload = new BookingPayload
            {
                firstname = NameFaker.FirstName(),
                lastname = NameFaker.LastName(),
                totalprice = NumberFaker.Number(9999),
                depositpaid = BooleanFaker.Boolean(),
                bookingdates = new BookingDates
                {
                    checkin = DateTimeFaker.BirthDay().AddDays(2),
                    checkout = DateTimeFaker.BirthDay().AddDays(20)
                },
                additionalneeds = Country.Name()
            };
            return bookingPayload;
        }
    }

    public class BookingPayload
    {
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates? bookingdates { get; set; }
        public string? additionalneeds { get; set; }
    }

    public class BookingDates
    {
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
    }
}