using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReceptionsListProject.Models;

namespace ReceptionsListProject.Pages_Receptions
{
    public class EditModel : PageModel
    {
        private readonly ReceptionsListProjectContext _context;

        public EditModel(ReceptionsListProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reception Reception { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reception == null)
            {
                return NotFound();
            }

            var reception =  await _context.Reception.FirstOrDefaultAsync(m => m.ID == id);
            if (reception == null)
            {
                return NotFound();
            }
            Reception = reception;
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

            _context.Attach(Reception).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptionExists(Reception.ID))
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

        private bool ReceptionExists(int id)
        {
          return (_context.Reception?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
