using System;
using System.Collections.Generic;


namespace Engaze.EventSourcing.Core
{
    public abstract class EventBase : IDomainEvent, IEquatable<EventBase>
    {
        private const string IdAsStringPrefix = "Evento-";

        public string AggregateIdAsString
        {
            get { return $"{IdAsStringPrefix}{AggregateId.ToString()}"; }
        }
        ////protected EventBase()
        ////{
        ////    EventId = AggregateId;
        ////}

        protected EventBase(Guid aggregateId) //: this()
        {
            AggregateId = aggregateId;
            EventId = aggregateId;
        }

        protected EventBase(Guid aggregateId, long aggregateVersion) : this(aggregateId)
        {
            AggregateVersion = aggregateVersion;
        }

        public Guid EventId { get; set; }

        public Guid AggregateId { get; set; }

        public long AggregateVersion { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as EventBase);
        }

        public bool Equals(EventBase other)
        {
            return other != null &&
                   EventId.Equals(other.EventId);
        }

        public override int GetHashCode()
        {
            return 290933282 + EqualityComparer<Guid>.Default.GetHashCode(EventId);
        }

        public virtual IDomainEvent WithAggregate(Guid aggregateId, long aggregateVersion)
        {

            this.AggregateId = aggregateId;
            this.AggregateVersion = aggregateVersion;
            return this;


        }
    }
}
