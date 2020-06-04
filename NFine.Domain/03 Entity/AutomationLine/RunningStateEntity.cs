using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.AutomationLine
{
    public class RunningStateEntity : IEntity<RunningStateEntity>
    {
        public int? id { get; set; }
        public string Picture_Tip { get; set; }
        public string Picture_Url { get; set; }
        public string Describe1 { get; set; }
        public string DescribeColor1 { get; set; }
        public string Describe2 { get; set; }
        public string DescribeColor2 { get; set; }
        public string Describe3 { get; set; }
        public string DescribeColor3 { get; set; }
        public string Describe4 { get; set; }
        public string DescribeColor4 { get; set; }
        public string Describe5 { get; set; }
        public string DescribeColor5 { get; set; }
        public string Describe6 { get; set; }
        public string DescribeColor6 { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
