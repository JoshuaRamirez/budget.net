using Budget.Application.Events.Core;

namespace Budget.Application.Events.Requested.Creation
{
    public class PayerRequested : Event<PayerRequested>
    {
        public PayerRequested()
        {
            EventName = nameof(PayerRequested);
        }
        public string Description { get; set; }
        public string PayerName { get; set; }
        public string Type { get; set; }
    }
}
