using Budget.Application.Events.Core;

namespace Budget.Application.Events.Requested.Creation
{
    public class CategoryRequested : Event<CategoryRequested>
    {
        public CategoryRequested()
        {
            EventName = nameof(CategoryRequested);
        }
        public string CategoryName { get; set; }
        public string Type { get; set; }
    }
}
