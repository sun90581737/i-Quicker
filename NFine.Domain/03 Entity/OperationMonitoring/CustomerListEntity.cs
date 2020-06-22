using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.OperationMonitoring
{
    public class CustomerListEntity : IEntity<CustomerListEntity>
    {
        public int Id { get; set; }	
        public int ParentId { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }
        public DateTime CreationTime { get; set; }	
        public int IsEffective { get; set; }
    }
}
