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
#pragma warning disable CS8618
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly ReceptionsListProjectContext _context;

        public IndexModel(ReceptionsListProjectContext context)
        {
            _context = context;
        }

        public IList<Reception> Reception { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ReceptionType { get; set; }
        public async Task OnGetAsync()
        {
          // Use LINQ to get list of genres.
                IQueryable<string> typeQuery = from m in _context.Reception
                                    orderby m.Type
                                    select m.Type;

    var receptions = from m in _context.Reception
                 select m;

    if (!string.IsNullOrEmpty(SearchString))
    {
        receptions = receptions.Where(s => s.Title.Contains(SearchString));
    }

    if (!string.IsNullOrEmpty(ReceptionType))
    {
        receptions = receptions.Where(x => x.Type == ReceptionType);
    }
    Types = new SelectList(await typeQuery.Distinct().ToListAsync());
    Reception = await receptions.ToListAsync();
        }
    }
    #pragma warning disable CS8618
#pragma warning disable CS8604
}
