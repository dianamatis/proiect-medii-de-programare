using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Matis_Diana_ProiectExamen.Data;
using Matis_Diana_ProiectExamen.Models;

namespace Matis_Diana_ProiectExamen.Pages.Brand
{
    public class CreateModel : PageModel
    {
        private readonly Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext _context;

        public CreateModel(Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Brand Brand { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Brand.Add(Brand);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
