using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.ViewModel
{
    public class ReservationViewModel
    {
        public string ReservationId { get; set; }

        [Required(ErrorMessage = "Your Name is required")]
        //[RegularExpression("[a-zA-Z0-9]+$", ErrorMessage = "Invalid Format")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        //[RegularExpression("[a-zA-Z0-9]+$", ErrorMessage = "Invalid Format")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Date Travel is required")]
        public string DateTravel { get; set; }

        [Required(ErrorMessage = "Hotel Rooms is required")]
        //[RegularExpression("[a-zA-Z0-9]+$", ErrorMessage = "Invalid Format")]
        public string HotelRooms { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
