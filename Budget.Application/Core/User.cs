using System;

namespace Budget.Application.Core
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            Created = new DateTime();
        }
        public static Guid Id { get; set; }
        public DateTime Created { get; set; }
    }
}
