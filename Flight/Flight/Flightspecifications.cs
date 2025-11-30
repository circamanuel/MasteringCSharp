using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class Flightspecifications
    {
        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(6, 3, 3)]
        [InlineData(10, 6, 4)]
        [InlineData(12, 8, 4)]
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

        [Theory]
        [InlineData(3, 1, 1, 3)]
        [InlineData(4, 2, 2, 4)]
        [InlineData(7, 5, 4, 6)]
        public void Canceling_bookings_frees_up_the_seats(
            int initialCapacity,
            int numberOfSeatsToBook,
            int numberOFSeatsToCancel,
            int remainingNumberOfSeats
            )

        {
            // given
            var flight = new Flight(initialCapacity);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToBook);

            // when
            flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: numberOFSeatsToCancel);

            // then
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        public void Doesnt_cancel_bookings_for_passengers_who_have_not_booked()
        {
            var flight = new Flight(3);
            var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 2);
            error.Should().BeOfType<BookingNotFoundError>();
        }
        [Fact]
       public void Returns_null_when_succesfully_cancels_a_booking()
        {
            var flight = new Flight(3);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: 1);
            var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 1);
            error.Should().BeNull();

        }

    }
}
