using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matis_Diana_ProiectExamen.Models
{
    public class PhoneData
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Condition> Conditions { get; set; }
        public IEnumerable<PhoneCondition> PhoneConditions { get; set; }
    }
}
