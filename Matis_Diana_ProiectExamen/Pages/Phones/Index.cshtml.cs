using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matis_Diana_ProiectExamen.Data;
using Matis_Diana_ProiectExamen.Models;

namespace Matis_Diana_ProiectExamen.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext _context;

        public IndexModel(Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext context)
        {
            _context = context;
        }

        public IList<Phone> Phone { get;set; }
        public PhoneData PhoneD { get; set; }
        public int PhoneID { get; set; }
        public int ConditionID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PhoneD = new PhoneData();

            PhoneD.Phones = await _context.Phone
            .Include(b => b.Brand)
            .Include(b => b.PhoneConditions)
            .ThenInclude(b => b.Condition)
            .AsNoTracking()
            .OrderBy(b => b.PhoneModel)
            .ToListAsync();

            if (id != null)
            {
                PhoneID = id.Value;
                Phone phone = PhoneD.Phones
                .Where(i => i.ID == id.Value).Single();
                PhoneD.Conditions = phone.PhoneConditions.Select(s => s.Condition);
            }
        }
    }
}
