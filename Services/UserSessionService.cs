using EventEase.Models;

namespace EventEase.Services
{
    public class UserSessionService
    {
        private readonly List<Registration> _userRegistrations = new();

        public List<Registration> GetUserRegistrations()
        {
            return _userRegistrations.ToList();
        }

        public void AddRegistration(Registration registration)
        {
            _userRegistrations.Add(registration);
        }

        public bool IsRegisteredForEvent(int eventId)
        {
            return _userRegistrations.Any(r => r.EventId == eventId);
        }

        public Registration? GetRegistrationForEvent(int eventId)
        {
            return _userRegistrations.FirstOrDefault(r => r.EventId == eventId);
        }
    }
}
