using System;
using System.Collections.Generic;

#nullable disable

namespace GrafanaSensorServer.Infra.Database
{
    public partial class Value
    {
        public string Sensor { get; set; }
        public double? Value1 { get; set; }
        public DateTime? ReadingTime { get; set; }
        public int Id { get; set; }

        public virtual Sensor SensorNavigation { get; set; }
    }
}
