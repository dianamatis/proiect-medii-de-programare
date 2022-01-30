using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Matis_Diana_ProiectExamen.Data;
using Matis_Diana_ProiectExamen.Models;

namespace Matis_Diana_ProiectExamen.Pages.Phones
{
    public class CreateModel : PhoneConditionsPageModel
    {
        private readonly Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext _context;

        public CreateModel(Matis_Diana_ProiectExamen.Data.Matis_Diana_ProiectExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Models.Brand>(), "ID", "BrandName");

            var phone = new Phone();
            phone.PhoneConditions = new List<PhoneCondition> ();

            PopulateAssignedConditionData(_context, phone);
            return Page();

        }

        [BindProperty]
        public Phone Phone { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedConditions)
        {
            var newPhone = new Phone();
            if (selectedConditions != null)
            {
                newPhone.PhoneConditions = new List<PhoneCondition>();
                foreach (var cat in selectedConditions)
                {
                    var catToAdd = new PhoneCondition
                    {
                        ConditionID = int.Parse(cat)
                    };
                    newPhone.PhoneConditions.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Phone>(
            newPhone,
            "Phone",
            i => i.PhoneModel, i => i.Capacity,
            i => i.Price, i => i.LunchDate, i => i.BrandID))
            {
                _context.Phone.Add(newPhone);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedConditionData(_context, newPhone);
            return Page();
        }


        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Phone.Add(Phone);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
