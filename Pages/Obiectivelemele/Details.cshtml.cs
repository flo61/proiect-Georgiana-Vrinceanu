using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Obiectivelemele
{
    public class DetailsModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DetailsModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

      public Obiective Obiective { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Obiective == null)
            {
                return NotFound();
            }

            var obiective = await _context.Obiective.FirstOrDefaultAsync(m => m.ID == id);
            if (obiective == null)
            {
                return NotFound();
            }
            else 
            {
                Obiective = obiective;
            }
            return Page();
        }
    }
}
