using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Trust
{
    public class IndexModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public IndexModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        public IList<Incredere> Incredere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Incredere != null)
            {
                Incredere = await _context.Incredere
                .Include(i => i.Todolist)
                .ThenInclude(b => b.Countries)

                .Include(i => i.Whocansee).ToListAsync();
            }
        }
    }
}
