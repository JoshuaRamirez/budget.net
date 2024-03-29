﻿using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;

namespace Budget.Application.Projections
{
    public class UserProjection : Projection<UserProjection>
    {
        public UserProjection()
        {
            AccountIds = new List<Guid>();
            CategoryIds = new List<Guid>();
            IncomeAccountIds = new List<Guid>();
            PayeeIds = new List<Guid>();
        }
        public List<Guid> AccountIds;
        public List<Guid> CategoryIds;
        public List<Guid> IncomeAccountIds;
        public List<Guid> PayeeIds;
        public string Email;
        public string FirstName;
        public string LastName;
        public string Password;
        public string UserName;
        public string Type;
    }
}
