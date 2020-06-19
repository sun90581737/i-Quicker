using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.OperationMonitoring
{
    public class UserEngineeringEntity : IEntity<UserEngineeringEntity>
    {
        public int? id { get; set; }
        public string Account { get; set; }
        public string RealName { get; set; }
        public int? CustomerAmount { get; set; }
        public string CustomerAmountColor { get; set; }
        public int? DeliveryCompletionRate { get; set; }
        public string DeliveryCompletionRateColor { get; set; }
        public int? OnTimeDeliveryMold { get; set; }
        public string OnTimeDeliveryMoldColor { get; set; }
        public int? LateDeliveryMold { get; set; }
        public string LateDeliveryMoldColor { get; set; }
        public int? MoldInProcess { get; set; }
        public string MoldInProcessColor { get; set; }
        public int? NormalProgress { get; set; }
        public string NormalProgressColor { get; set; }
        public int? ScheduleDelay { get; set; }
        public string ScheduleDelayColor { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
