using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class Category : Projection<Category>
    {
        public string CategoryName { get; set; }
        public string Type { get; set; }
    }
}
