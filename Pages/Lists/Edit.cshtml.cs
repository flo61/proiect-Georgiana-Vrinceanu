using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Pages.Lists
{
    public class EditModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public EditModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Todolist Todolist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Todolist == null)
            {
                return NotFound();
            }

            var todolist =  await _context.Todolist.FirstOrDefaultAsync(m => m.ID == id);
            if (todolist == null)
            {
                return NotFound();
            }
            Todolist = todolist;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Todolist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodolistExists(Todolist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodolistExists(int id)
        {
          return _context.Todolist.Any(e => e.ID == id);
        }
    }
}
