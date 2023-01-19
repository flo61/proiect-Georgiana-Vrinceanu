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

namespace Geo.Pages.Trust
{
    public class EditModel : PageModel
    {
        private readonly Geo.Data.GeoContext _context;

        public EditModel(Geo.Data.GeoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Incredere Incredere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Incredere == null)
            {
                return NotFound();
            }

            var incredere =  await _context.Incredere.FirstOrDefaultAsync(m => m.ID == id);
            if (incredere == null)
            {
                return NotFound();
            }
            Incredere = incredere;
           ViewData["TodolistID"] = new SelectList(_context.Todolist, "ID", "ID");
           ViewData["WhocanseeID"] = new SelectList(_context.Whocansee, "ID", "ID");
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

            _context.Attach(Incredere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncredereExists(Incredere.ID))
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

        private bool IncredereExists(int id)
        {
          return _context.Incredere.Any(e => e.ID == id);
        }
    }
}
