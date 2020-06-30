using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.QualityOptimization
{
    public class QualityOExceptionalDetailEntity : IEntity<QualityOExceptionalDetailEntity>
    {
        public int id { get; set; }
        public string ProjectNo { get; set; }
        public string ModuleNumber { get; set; }
        public string WorkpieceNo { get; set; }	
        public string ExceptionalProcedure { get; set; }
        public string TreatmentMethod { get; set; }	
        public string Colour { get; set; }	
        public DateTime CreationTime { get; set; }	
        public int IsEffective { get; set; }
    }
}
