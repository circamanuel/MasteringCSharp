using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class Flightspecifications
    {
        [Theory]
        [InlineData(3,1,2)]
        [InlineData(6,3,3)]
        [InlineData(10,6,4)]
        [InlineData(12,8,4)]
        public void Booking_reduces_the_numbers_of_seats(int seatCapacity, int numberOfSeats, int remainingNumberOfseats)
        {

            // Given
            var flight = new Flight(seatCapacity: seatCapacity);
            // When
            flight.Book("new@test.com", numberOfSeats);
            // Then
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfseats);

        }

            [Fact]
            public void Avoids_overbooking()
            {
                // Given
                var flight = new Flight(seatCapacity: 3);
                // When
                var error = flight.Book("test@mail.com", 4);
                // then
                error.Should().BeOfType<OverbookingError>();

            }

        [Fact]
        public void Books_flights_successfully()
        {
            var flight = new Flight(seatCapacity: 3);
            var error = flight.Book("info@mail.com", 1);
            error.Should().BeNull();
        }

        [Fact]
        public void Remembers_bookings()
        {
            var flight = new Flight(seatCapacity: 150);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: 4);
            flight.BookingList.Should().ContainEquivalentOf(new Booking("a@b.com", 4));
        }
    }
}
