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
    public class DetailsModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DetailsModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

      public Todolist Todolist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Todolist == null)
            {
                return NotFound();
            }

            var todolist = await _context.Todolist.FirstOrDefaultAsync(m => m.ID == id);
            if (todolist == null)
            {
                return NotFound();
            }
            else 
            {
                Todolist = todolist;
            }
            return Page();
        }
    }
}
