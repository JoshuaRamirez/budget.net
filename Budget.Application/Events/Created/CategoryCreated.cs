﻿using Budget.Application.Events.Core;
using System;

namespace Budget.Application.Events.Created
{
    public class CategoryCreated : Event<CategoryCreated>
    {
        public CategoryCreated()
        {
            EventName = nameof(CategoryCreated);
        }
        public Guid CategoryId { get; set; }
    }
}
