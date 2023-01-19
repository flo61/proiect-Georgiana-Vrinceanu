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

namespace Geo.Pages.Oamenideincredere
{
    public class EditModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public EditModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Whocansee Whocansee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Whocansee == null)
            {
                return NotFound();
            }

            var whocansee =  await _context.Whocansee.FirstOrDefaultAsync(m => m.ID == id);
            if (whocansee == null)
            {
                return NotFound();
            }
            Whocansee = whocansee;
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

            _context.Attach(Whocansee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhocanseeExists(Whocansee.ID))
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

        private bool WhocanseeExists(int id)
        {
          return _context.Whocansee.Any(e => e.ID == id);
        }
    }
}
