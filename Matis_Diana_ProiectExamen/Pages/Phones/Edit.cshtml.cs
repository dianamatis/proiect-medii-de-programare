using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matis_Diana_ProiectExamen.Data;
using Matis_Diana_ProiectExamen.Models;

namespace Matis_Diana_ProiectExamen.Pages.Phones
{
    public class EditModel : PhoneConditionsPageModel

    {
        private readonly Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext _context;

        public EditModel(Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.Include(p => p.Brand).Include(p => p.PhoneConditions).ThenInclude(p => p.Condition).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Phone == null)
            {
                return NotFound();
            }
            PopulateAssignedConditionData(_context, Phone);
            ViewData["BrandID"] = new SelectList(_context.Set<Models.Brand>(), "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedConditions)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneToUpdate = await _context.Phone
                .Include(i => i.Brand)
                .Include(i => i.PhoneConditions)
                .ThenInclude(i => i.Condition)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (phoneToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Phone>(phoneToUpdate,"Phone",i => i.PhoneModel, i => i.Capacity,i => i.Price, i => i.LunchDate, i => i.Brand))
            {
                UpdatePhoneConditions(_context, selectedConditions, phoneToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdatePhoneConditions(_context, selectedConditions, phoneToUpdate);
            PopulateAssignedConditionData(_context, phoneToUpdate);
            return Page();
        }
    }
}

