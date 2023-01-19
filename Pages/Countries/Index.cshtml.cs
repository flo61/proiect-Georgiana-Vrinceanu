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
    public class IndexModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public IndexModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        public IList<Countriestovisit> Countriestovisit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Countriestovisit != null)
            {
                Countriestovisit = await _context.Countriestovisit.ToListAsync();
            }
        }
    }
}
