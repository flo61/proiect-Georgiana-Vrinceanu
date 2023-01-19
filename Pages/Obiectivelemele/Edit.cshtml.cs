using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Obiectivelemele
{
    public class EditModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public EditModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Obiective Obiective { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Obiective == null)
            {
                return NotFound();
            }

            var obiective =  await _context.Obiective.FirstOrDefaultAsync(m => m.ID == id);
            if (obiective == null)
            {
                return NotFound();
            }
            Obiective = obiective;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Obiective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObiectiveExists(Obiective.ID))
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

        private bool ObiectiveExists(int id)
        {
          return _context.Obiective.Any(e => e.ID == id);
        }
    }
}
