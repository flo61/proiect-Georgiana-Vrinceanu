using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Oamenideincredere
{
    public class DeleteModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DeleteModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Whocansee Whocansee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Whocansee == null)
            {
                return NotFound();
            }

            var whocansee = await _context.Whocansee.FirstOrDefaultAsync(m => m.ID == id);

            if (whocansee == null)
            {
                return NotFound();
            }
            else 
            {
                Whocansee = whocansee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Whocansee == null)
            {
                return NotFound();
            }
            var whocansee = await _context.Whocansee.FindAsync(id);

            if (whocansee != null)
            {
                Whocansee = whocansee;
                _context.Whocansee.Remove(Whocansee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
