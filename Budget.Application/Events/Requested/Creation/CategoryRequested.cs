using Budget.Application.Events.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Events.Requested.Creation
{
    public class CategoryRequested : Event<CategoryRequested>
    {
        public string CategoryName { get; set; }
        public string Type { get; set; }
    }
}
