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
    public class DeleteModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public DeleteModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Todolist == null)
            {
                return NotFound();
            }
            var todolist = await _context.Todolist.FindAsync(id);

            if (todolist != null)
            {
                Todolist = todolist;
                _context.Todolist.Remove(Todolist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
