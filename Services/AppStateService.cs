using System.ComponentModel.DataAnnotations;

namespace EventEase.Services
{
    public class UserSession
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string Email { get; set; } = string.Empty;

        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(Email);
    }

    public class AppStateService
    {
        public UserSession CurrentUser { get; private set; } = new();
        public HashSet<int> RegisteredEvents { get; private set; } = new();

        private readonly Dictionary<int, int> _attendanceCounts = new()
        {
            { 1, 42 },
            { 2, 18 },
            { 3, 75 }
        };

        public event Action? OnChange;

        public void SetUser(string name, string email)
        {
            CurrentUser.FullName = name.Trim();
            CurrentUser.Email = email.Trim();
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            CurrentUser = new UserSession();
            RegisteredEvents.Clear();
            NotifyStateChanged();
        }

        public int GetAttendanceCount(int eventId) =>
            _attendanceCounts.TryGetValue(eventId, out var count) ? count : 0;

        public bool RegisterForEvent(int eventId)
        {
            if (RegisteredEvents.Contains(eventId)) return false;

            RegisteredEvents.Add(eventId);
            if (_attendanceCounts.ContainsKey(eventId))
                _attendanceCounts[eventId]++;
            else
                _attendanceCounts[eventId] = 1;

            NotifyStateChanged();
            return true;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}