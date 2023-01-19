using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Countries
{
    public class DeleteModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DeleteModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Countriestovisit Countriestovisit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Countriestovisit == null)
            {
                return NotFound();
            }

            var countriestovisit = await _context.Countriestovisit.FirstOrDefaultAsync(m => m.ID == id);

            if (countriestovisit == null)
            {
                return NotFound();
            }
            else 
            {
                Countriestovisit = countriestovisit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Countriestovisit == null)
            {
                return NotFound();
            }
            var countriestovisit = await _context.Countriestovisit.FindAsync(id);

            if (countriestovisit != null)
            {
                Countriestovisit = countriestovisit;
                _context.Countriestovisit.Remove(Countriestovisit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
