using Budget.Application.Events.Core;

namespace Budget.Application.Events.Requested.Creation
{
    public class UserRequested : Event<UserRequested>
    {
        public UserRequested()
        {
            EventName = nameof(UserRequested);
        }
        public string UserName { get; set; }
    }
}
