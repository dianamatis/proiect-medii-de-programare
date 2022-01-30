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

namespace Matis_Diana_ProiectExamen.Pages.Conditions
{
    public class EditModel : PageModel
    {
        private readonly Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext _context;

        public EditModel(Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Condition Condition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Condition = await _context.Condition.FirstOrDefaultAsync(m => m.ID == id);

            if (Condition == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Condition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionExists(Condition.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConditionExists(int id)
        {
            return _context.Condition.Any(e => e.ID == id);
        }
    }
}
