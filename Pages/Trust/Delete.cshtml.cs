using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Trust
{
    public class DeleteModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DeleteModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Incredere Incredere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Incredere == null)
            {
                return NotFound();
            }

            var incredere = await _context.Incredere.FirstOrDefaultAsync(m => m.ID == id);

            if (incredere == null)
            {
                return NotFound();
            }
            else 
            {
                Incredere = incredere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Incredere == null)
            {
                return NotFound();
            }
            var incredere = await _context.Incredere.FindAsync(id);

            if (incredere != null)
            {
                Incredere = incredere;
                _context.Incredere.Remove(Incredere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
