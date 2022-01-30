using Matis_Diana_ProiectExamen.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matis_Diana_ProiectExamen.Models
{
    public class PhoneConditionsPageModel : PageModel
    {
        public List<AssignedConditionData> AssignedConditionDataList;
        public void PopulateAssignedConditionData(Matis_Diana_ProiectExamenContext context,
        Phone phone)
        {
            var allConditions = context.Condition;
            var phoneConditions = new HashSet<int>(
            phone.PhoneConditions.Select(c => c.ConditionID)); //
            AssignedConditionDataList = new List<AssignedConditionData>();
            foreach (var cond in allConditions)
            {
                AssignedConditionDataList.Add(new AssignedConditionData
                {
                    ConditionID = cond.ID,
                    Name = cond.ConditionName,
                    Assigned = phoneConditions.Contains(cond.ID)
                });
            }
        }
        public void UpdatePhoneConditions(Matis_Diana_ProiectExamenContext context,
        string[] selectedConditions, Phone phoneToUpdate)
        {
            if (selectedConditions == null)
            {
                phoneToUpdate.PhoneConditions = new List<PhoneCondition>();
                return;
            }
            var selectedConditionsHS = new HashSet<string>(selectedConditions);
            var phoneConditions = new HashSet<int>
            (phoneToUpdate.PhoneConditions.Select(c => c.Condition.ID));
            foreach (var cond in context.Condition)
            {
                if (selectedConditionsHS.Contains(cond.ID.ToString()))
                {
                    if (!phoneConditions.Contains(cond.ID))
                    {
                        phoneToUpdate.PhoneConditions.Add(
                        new PhoneCondition
                        {
                            PhoneID = phoneToUpdate.ID,
                            ConditionID = cond.ID
                        });
                    }
                }
                else
                {
                    if (phoneConditions.Contains(cond.ID))
                    {
                        PhoneCondition phoneToRemove
                        = phoneToUpdate
                        .PhoneConditions
                        .SingleOrDefault(i => i.ConditionID == cond.ID);
                        context.Remove(phoneToRemove);
                    }
                }
            }

        }
    }
}
