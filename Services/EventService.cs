using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly List<Event> _events;
        private readonly object _lock = new object();

        public EventService()
        {
            // Initialize with sample data
            _events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "Annual Tech Conference 2026",
                    Date = new DateTime(2026, 3, 15),
                    Location = "Convention Center, San Francisco",
                    Description = "Join industry leaders for insights on emerging technologies",
                    ImageUrl = "https://picsum.photos/800/400?random=1",
                    Category = "Technology",
                    Capacity = 500,
                    RegisteredAttendees = 234
                },
                new Event
                {
                    Id = 2,
                    Name = "Spring Gala Dinner",
                    Date = new DateTime(2026, 4, 20),
                    Location = "Grand Hotel Ballroom, New York",
                    Description = "An elegant evening of networking and entertainment",
                    ImageUrl = "https://picsum.photos/800/400?random=2",
                    Category = "Social",
                    Capacity = 300,
                    RegisteredAttendees = 187
                },
                new Event
                {
                    Id = 3,
                    Name = "Product Launch Event",
                    Date = new DateTime(2026, 5, 10),
                    Location = "Innovation Hub, Austin",
                    Description = "Be the first to see our revolutionary new product",
                    ImageUrl = "https://picsum.photos/800/400?random=3",
                    Category = "Corporate",
                    Capacity = 200,
                    RegisteredAttendees = 156
                }
            };
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            return Task.FromResult(_events);
        }

        public Task<Event?> GetEventByIdAsync(int id)
        {
            var eventItem = _events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(eventItem);
        }

        public Task<bool> RegisterForEventAsync(int eventId)
        {
            lock (_lock)
            {
                var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
                if (eventItem != null && eventItem.RegisteredAttendees < eventItem.Capacity)
                {
                    eventItem.RegisteredAttendees++;
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
        }

        public Task<bool> RegisterAttendeeAsync(Registration registration)
        {
            lock (_lock)
            {
                var eventItem = _events.FirstOrDefault(e => e.Id == registration.EventId);
                if (eventItem != null && eventItem.RegisteredAttendees < eventItem.Capacity)
                {
                    registration.Id = eventItem.Attendees.Count + 1;
                    registration.RegisteredAt = DateTime.Now;
                    eventItem.Attendees.Add(registration);
                    eventItem.RegisteredAttendees++;
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
        }

        public Task<List<Registration>> GetEventAttendeesAsync(int eventId)
        {
            var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
            return Task.FromResult(eventItem?.Attendees ?? new List<Registration>());
        }

        public Task<bool> IsEmailRegisteredForEventAsync(int eventId, string email)
        {
            var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
            if (eventItem != null)
            {
                return Task.FromResult(eventItem.Attendees.Any(a =>
                    a.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));
            }
            return Task.FromResult(false);
        }
    }
}