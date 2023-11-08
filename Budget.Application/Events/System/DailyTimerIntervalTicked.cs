using Budget.Application.Events.Core;

namespace Budget.Application.Events.System
{
    public class DailyTimerIntervalTicked : Event<DailyTimerIntervalTicked>
    {
        public DailyTimerIntervalTicked()
        {
            EventName = nameof(DailyTimerIntervalTicked);
        }
    }
}
