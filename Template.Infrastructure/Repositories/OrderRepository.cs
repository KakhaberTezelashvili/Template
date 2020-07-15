using System;
using System.Threading.Tasks;
using Template.Domain.Repositories;

namespace Template.Infrastructure.Repositories
{
    public class OrderRepository : DataAccessBase, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString) { }

        public async Task<dynamic> FindAsync(Guid orderId)
        {
            try
            {
                Open();

                // TODO select all events by aggregate id
                // TODO call this await QueryAsync<EventRow>("Write.GetProcessTypeAggregateEvents", new { aggregateId });

                //foreach (var @event in aggregateStory)
                //{
                //    // TODO apply event
                //    aggregate.ApplyEvent(_serializer.Deserialize<IDomainEvent>(@event.EventType, @event.EventData), @event.AggregateVersion);
                //}

                Close();
            }
            finally
            {
                Dispose();
            }

            return null;
        }

        public async Task SaveAsync(dynamic order)
        {
            //var uncomittedEvents = aggregate.GetUncommittedEvents();
            //
            //try
            //{
            //    Open();
            //    BeginTransaction();
            //
            //    foreach (var @event in uncomittedEvents)
            //    {

            // TODO call it await ExecuteAsync("Write.CreateProcessTypeEvent", new { aggregateId, aggregateVersion, eventType, eventData, correlationId, createDate });

            //    CommitTransaction();
            //    Close();
            //}
            //catch
            //{
            //    RollBackTransaction();
            //}
            //finally
            //{
            //    Dispose();
            //}

            //aggregate.ClearUncommittedEvents();
        }
    }
}