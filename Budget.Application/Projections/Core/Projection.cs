using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Application.Projections.Core
{
    public class Projection<TProjection> where TProjection : Projection<TProjection>
    {

        public Guid Id { get; set; }
        public static List<TProjection> Projections { get; set; }


        public Projection()
        {
            Id = new Guid();
            Projections = new List<TProjection>();
        }

    }
}
