using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class BookDto
    {
        public String PassengerEmail { get; set; }
        public int NumberOfSeats { get; set; }
        public Guid FlightId { get; set; }

        public BookDto(Guid flightId, string passengerEmail, int numberOfSeats)
        {
            FlightId = flightId;
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}
