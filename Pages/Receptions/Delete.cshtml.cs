using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReceptionsListProject.Models;

namespace ReceptionsListProject.Pages_Receptions
{
    public class DeleteModel : PageModel
    {
        private readonly ReceptionsListProjectContext _context;

        public DeleteModel(ReceptionsListProjectContext context)
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

            var reception = await _context.Reception.FirstOrDefaultAsync(m => m.ID == id);

            if (reception == null)
            {
                return NotFound();
            }
            else 
            {
                Reception = reception;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reception == null)
            {
                return NotFound();
            }
            var reception = await _context.Reception.FindAsync(id);

            if (reception != null)
            {
                Reception = reception;
                _context.Reception.Remove(Reception);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
