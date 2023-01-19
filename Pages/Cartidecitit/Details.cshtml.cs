using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Cartidecitit
{
    public class DetailsModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DetailsModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

      public Carte Carte { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Carte == null)
            {
                return NotFound();
            }

            var carte = await _context.Carte.FirstOrDefaultAsync(m => m.ID == id);
            if (carte == null)
            {
                return NotFound();
            }
            else 
            {
                Carte = carte;
            }
            return Page();
        }
    }
}
