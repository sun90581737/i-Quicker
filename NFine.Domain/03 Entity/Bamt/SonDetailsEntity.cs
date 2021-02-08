using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Bamt
{
    public class SonDetailsEntity : IEntity<SonDetailsEntity>
    {
        public int? id { get; set; }
        public string DeviceName { get; set; }
        public string Time { get; set; }
        public string Result { get; set; }
        public double XFlatness { get; set; }
        public double YFlatness { get; set; }
        public double XZRightAngle { get; set; }
        public double YZRightAngle { get; set; }
        public double XYRightAngle { get; set; }
        public double XRepeatPrecision { get; set; }
        public double YRepeatPrecision { get; set; }
        public double ZRepeatPrecision { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
