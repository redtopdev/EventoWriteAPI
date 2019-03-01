
namespace Engaze.Evento.Domain.Entity
{
    using Engaze.Evento.Contract;
    using Engaze.Evento.Domain.Event;
    using Engaze.Evento.Domain.ValueObjects;
    using Engaze.EventSourcing.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Evento : AggregateRoot
    {
        public Evento(Guid Id, EventoContract eventoContract) : this()
        {
            var @event = new EventoCreated(Id, eventoContract);
            base.RaiseEvent(@event);
        }

        public Evento()
        {
            //domain events registered (event sourcing pattern)
            Register<EventoCreated>(when);
            Register<EventoEnded>(when);
            Register<ParticipantsListUpdated>(when);
            Register<EventoDeleted>(when);
            Register<EventoExtended>(when);
            Register<ParticipantLeft>(when);
            Register<ParticipantStateUpdated>(when);
        }

        public void DeleteEvent()
        {
            var @event = new EventoDeleted(Id);
            base.RaiseEvent(@event);
        }

        public void EndEvent()
        {
            var @event = new EventoEnded(Id, DateTime.UtcNow);
            base.RaiseEvent(@event);
        }

        public void ExtendEvento(DateTime extendedTime)
        {
            var @event = new EventoExtended(Id, extendedTime);
            base.RaiseEvent(@event);
        }

        public void LeaveEvento(Guid participantId)
        {
            var @event = new ParticipantLeft(Id, participantId);
            base.RaiseEvent(@event);
        }

        public void UpdateParticipantList(ICollection<Guid> participantList)
        {
            var @event = new ParticipantsListUpdated(Id, participantList);
            base.RaiseEvent(@event);
        }

        public void UpdateParticipantState(Guid participantId, EventAcceptanceState newState)
        {
            var @event = new ParticipantStateUpdated(Id, participantId, newState);
            base.RaiseEvent(@event);
        }


        //domain event handler
        private void when(EventoEnded e)
        {
            this.EndTime = e.EndTime;
            this.Id = e.AggregateId;
        }

        private void when(ParticipantStateUpdated e)
        {
            this.ParticipantList.Where(p => p.UserId == e.ParticipantId).FirstOrDefault().UpdateAcceptanceState(e.NewState);
            this.Id = e.AggregateId;
        }

        private void when(ParticipantLeft e)
        {
            this.ParticipantList.Remove(this.ParticipantList.Where(p => p.UserId == e.ParticipantId).FirstOrDefault());
            this.Id = e.AggregateId;
        }

        private void when(EventoExtended e)
        {
            this.EndTime = e.EndTime;
            this.Id = e.AggregateId;
        }

        private void when(EventoDeleted e)
        {
            this.IsDeleted = true;
        }

        private void when(ParticipantsListUpdated e)
        {
            this.ParticipantList.ToList().RemoveAll(participant => !e.ParticipantList.Contains(participant.UserId));
            e.ParticipantList.ToList().Except(ParticipantList.Select(p => p.UserId)).ToList()
                .ForEach(p => this.ParticipantList.Add(new Participant(p, EventAcceptanceState.Pending)));
            this.Id = e.AggregateId;
        }

        //domain event handler
        private void when(EventoCreated e)
        {
            base.Id = e.AggregateId;
            this.InitiatorId = e.InitiatorId;
            this.Description = e.Description;
            this.Name = e.Name;
            this.StartTime = e.StartTime;
            this.EndTime = e.EndTime;
            this.EventState = e.EventState;
            this.EventType = e.EventType;
            this.ParticipantList = new List<Participant>();
            e.Participants.ToList().ForEach(participant => this.ParticipantList.Add(new Participant(participant.UserId, participant.AcceptanceState)));
            this.Destination = new Location()
            {
                Address = e.Destination.Address,
                Name = e.Destination.Name,
                Latitude = e.Destination.Latitude,
                Longitude = e.Destination.Longitude
            };
            if (e.Recurrence != null)
            {
                this.EventoRecurrence = new Recurrence()
                {
                    ActualStartTime = e.Recurrence.ActualStartTime,
                    Count = e.Recurrence.Count,
                    DaysOfWeek = e.Recurrence.DaysOfWeek,
                    Frequency = e.Recurrence.Frequency,
                    FrequencyType = e.Recurrence.FrequencyType,
                    Remaining = e.Recurrence.Remaining
                };
            }
        }


        public string Name { get; private set; }

        public EventType EventType { get; private set; }

        public string Description { get; private set; }

        public Guid InitiatorId { get; private set; }

        public EventState EventState { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public ICollection<Participant> ParticipantList { get; private set; }

        public Location Destination { get; private set; }

        public Recurrence EventoRecurrence { get; private set; }

        public bool IsDeleted { get; private set; } = false;

    }
}
