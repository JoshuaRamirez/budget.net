using Budget.Application.Projections.Core;

namespace Budget.Application.Projections
{
    public class Category : Projection<Category>
    {
        public string CategoryName { get; set; }
        public string Type { get; set; }
    }
}
