using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class ReservationModel
    {
        [Key]
        public string ReservationId { get; set; }
        public string FullName { get; set; }
        public string Destination { get; set; }
        public string DateTravel { get; set; }
        public string HotelRooms { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsDeleted { get; set; }
    }
}
