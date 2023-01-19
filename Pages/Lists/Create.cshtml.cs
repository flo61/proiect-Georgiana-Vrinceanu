using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Geo.Data;
using Geo.Models;
using System.Security.Policy;

namespace Geo.Pages.Lists
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
            ViewData["CountriestovisitID"] = new SelectList(_context.Set<Countriestovisit>(), "ID",
"CountryName");
            ViewData["ObiectiveID"] = new SelectList(_context.Set<Obiective>(), "ID",
"ObiectivulMeu");
            ViewData["CarteID"] = new SelectList(_context.Set<Carte>(), "ID",
"DenumireCarte");
            ViewData["MaterieID"] = new SelectList(_context.Set<Materie>(), "ID",
"Materiipecaresaleiau");
            return Page();
        }

        [BindProperty]
        public Todolist Todolist { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todolist.Add(Todolist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
