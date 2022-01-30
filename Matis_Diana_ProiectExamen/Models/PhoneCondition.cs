using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matis_Diana_ProiectExamen.Models
{
    public class PhoneCondition
    {
        public int ID { get; set; }
        public int PhoneID { get; set; }
        public Phone Phone { get; set; }
        public int ConditionID { get; set; }
        public Condition Condition { get; set; }
    }
}
