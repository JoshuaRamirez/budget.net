using Budget.Application.Projections.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections
{
    public class UserProjection : Projection<UserProjection>
    {
        public string UserName { get; internal set; }
    }
}
