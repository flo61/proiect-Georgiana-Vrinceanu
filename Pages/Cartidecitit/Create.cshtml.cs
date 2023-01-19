using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Cartidecitit
{
    public class CreateModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public CreateModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Carte Carte { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Carte.Add(Carte);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
