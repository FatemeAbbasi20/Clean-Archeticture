using System.ComponentModel.DataAnnotations.Schema;

namespace Clean_Arch.Domain.Shared
{
    public class AggregateRoot:BaseEntity
    {
        private readonly List<BaseDoaminEvent> _domainEvents= new List<BaseDoaminEvent>();
        [NotMapped]
        public List<BaseDoaminEvent>DomainEvents => _domainEvents;

        public void AddDomainEvent(BaseDoaminEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(BaseDoaminEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }


    }
}
