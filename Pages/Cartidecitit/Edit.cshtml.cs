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

namespace Geo.Pages.Cartidecitit
{
    public class EditModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public EditModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Carte Carte { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Carte == null)
            {
                return NotFound();
            }

            var carte =  await _context.Carte.FirstOrDefaultAsync(m => m.ID == id);
            if (carte == null)
            {
                return NotFound();
            }
            Carte = carte;
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

            _context.Attach(Carte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarteExists(Carte.ID))
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

        private bool CarteExists(int id)
        {
          return _context.Carte.Any(e => e.ID == id);
        }
    }
}
