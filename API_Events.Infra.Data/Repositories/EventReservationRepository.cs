﻿using API_Events.Core.Interfaces;
using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
using Dapper;

namespace API_Events.Infra.Data.Repositories
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConnectionDataBase _cnnDataBase;
        public EventReservationRepository(IConnectionDataBase cnnDataBase)
        {
            _cnnDataBase = cnnDataBase;
        }

        public List<EventReservation> GetReservationList()
        {
            var query = "SELECT * FROM EventReservation";
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Query<EventReservation>(query).ToList();
        }

        //public List<EventReservation> GetReservationEventByPerson(string title, string personName)
        //{
        //    return GetReservationList();
        //}

        public bool InsertReservation(EventReservation newEventReservation)
        {
            var query = "INSERT INTO EventReservation VALUES (@idEvent, @PersonName, @Quantity)";
            var parameters = new DynamicParameters(new
            {
                newEventReservation.IdEvent,
                newEventReservation.PersonName,
                newEventReservation.Quantity,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateQuantityReservation(long idReservation, EventReservation eventReservation)
        {
            var query = "UPDATE EventReservation SET Quantity = @quantity WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new
            {
                eventReservation.Quantity,
                eventReservation.IdReservation,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new { idReservation };
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
