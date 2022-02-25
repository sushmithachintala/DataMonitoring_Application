using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class QueueModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public float SLA_Percent { get; set; }
        public float SLA_Time { get; set; }
    }

    public class MoniterModel
    {
        [Key]
        public int QueueGroupID { get; set; }
        public float TalkTime { get; set; }
        public float AfterCallWorkTime { get; set; }
        public float Handled { get; set; }
        public float Offered { get; set; }
        public float HandledWithinSL { get; set; }
    }
    public class MoniterViewModel
    {
        [Key]
        public int QueueGroupID { get; set; }
        public float TalkTime { get; set; }
        public float AfterCallWorkTime { get; set; }
        public float Handled { get; set; }
        public float Offered { get; set; }
        public float HandledWithinSL { get; set; }
        public string Name { get; set; }
        public float SLA_Percent { get; set; }
        public float SLA_Time { get; set; }
        public string Color { get; set; }
    }
}
