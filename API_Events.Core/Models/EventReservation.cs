﻿namespace API_Events.Core.Models
{
    public class EventReservation
    {
        public long IdReservation { get; set; }
        public long IdEvent { get; set; }
        public string PersonName { get; set; }
        public long Quantity { get; set; }
    }
}
