using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Lists
{
    public class IndexModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public IndexModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        public IList<Todolist> Todolist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Todolist != null)
            {
                Todolist = await _context.Todolist
                    .Include(b => b.Countriestovisit)
                    .Include(b => b.Obiective)
                    .Include(b => b.Carte)
                    .Include(b => b.Materie)
                    .ToListAsync();
            }
        }
    }
}
