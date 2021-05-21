using Budget.Application.Projection.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projection
{
    public class User : Projection<User>
    {
        public User()
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
