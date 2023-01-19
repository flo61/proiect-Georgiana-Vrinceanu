using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Geo.Data;
using Geo.Models;
using Microsoft.EntityFrameworkCore;

namespace Geo.Pages.Trust
{
    public class CreateModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public CreateModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Todolist
               .Include(b => b.Countries)
                  .Select(x => new
          {
            x.ID,
            Intregnumele = x.Movies + " - " + x.Countries + " " +
        x.Rude
         });

            ViewData["TodolistID"] = new SelectList(bookList, "ID", "Intregnumele");
        ViewData["WhocanseeID"] = new SelectList(_context.Whocansee, "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Incredere Incredere { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Incredere.Add(Incredere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
