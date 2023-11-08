using Budget.Application.Events.Core;

namespace Budget.Application.Events.Requested.Creation
{
    public class PayeeRequested : Event<PayeeRequested>
    {
        public PayeeRequested()
        {
            EventName = nameof(PayeeRequested);
        }
        public string Description { get; set; }
        public string PayeeName { get; set; }
        public string Type { get; set; }
    }
}
