using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReceptionsListProject.Models;

namespace ReceptionsListProject.Pages_Receptions
{
    public class CreateModel : PageModel
    {
        private readonly ReceptionsListProjectContext _context;

        public CreateModel(ReceptionsListProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reception Reception { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reception == null || Reception == null)
            {
                return Page();
            }

            _context.Reception.Add(Reception);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
