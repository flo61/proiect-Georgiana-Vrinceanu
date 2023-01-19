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
    public class DetailsModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DetailsModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

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
    }
}
