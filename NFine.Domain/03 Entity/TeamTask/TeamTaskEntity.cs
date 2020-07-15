using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.TeamTask
{
    public class TeamTaskEntity : IEntity<TeamTaskEntity>
    {
        public int? id { get; set; }
        public string Mold_No { get; set; }
        public string Part_Number { get; set; }
        public string Process_Name { get; set; }
        public string Planned_Equipment { get; set; }
        public DateTime? Start_Time { get; set; }
        public DateTime? END_Time { get; set; }
        public DateTime? Latest_Start_Time { get; set; }
        public string Working_Hours { get; set; }
        public string Customer { get; set; }
        public string Mold_Kernel_Material { get; set; }
        public string Category { get; set; }
        public string Team { get; set; }
        public string Colour { get; set; }
        public int? IsEffective { get; set; }

    }
}
