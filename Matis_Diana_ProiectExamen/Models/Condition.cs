using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matis_Diana_ProiectExamen.Models
{
    public class Condition
    {
        public int ID { get; set; }
        public string ConditionName { get; set; }
        public ICollection<PhoneCondition> PhoneConditions { get; set; }
    }
}
