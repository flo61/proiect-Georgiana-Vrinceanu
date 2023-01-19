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
    public class IndexModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public IndexModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        public IList<Materie> Materie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Materie != null)
            {
                Materie = await _context.Materie.ToListAsync();
            }
        }
    }
}
