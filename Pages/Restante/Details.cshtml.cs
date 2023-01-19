using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Restante
{
    public class DetailsModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DetailsModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

      public Materie Materie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Materie == null)
            {
                return NotFound();
            }

            var materie = await _context.Materie.FirstOrDefaultAsync(m => m.ID == id);
            if (materie == null)
            {
                return NotFound();
            }
            else 
            {
                Materie = materie;
            }
            return Page();
        }
    }
}
