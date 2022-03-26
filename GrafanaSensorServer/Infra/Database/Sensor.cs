using System;
using System.Collections.Generic;

#nullable disable

namespace GrafanaSensorServer.Infra.Database
{
    public partial class Sensor
    {
        public Sensor()
        {
            Values = new HashSet<Value>();
        }

        public string Name { get; set; }
        public string State { get; set; }
        public DateTime? StateChangeTime { get; set; }

        public virtual ICollection<Value> Values { get; set; }
    }
}
