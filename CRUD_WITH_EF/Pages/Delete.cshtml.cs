using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_WITH_EF.Data;
using CRUD_WITH_EF.Models;

namespace CRUD_WITH_EF.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly CRUD_WITH_EF.Data.CRUD_WITH_EFContext _context;

        public DeleteModel(CRUD_WITH_EF.Data.CRUD_WITH_EFContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NewEmployee NewEmployee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NewEmployee == null)
            {
                return NotFound();
            }

            var newemployee = await _context.NewEmployee.FirstOrDefaultAsync(m => m.Empid == id);

            if (newemployee == null)
            {
                return NotFound();
            }
            else 
            {
                NewEmployee = newemployee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NewEmployee == null)
            {
                return NotFound();
            }
            var newemployee = await _context.NewEmployee.FindAsync(id);

            if (newemployee != null)
            {
                NewEmployee = newemployee;
                _context.NewEmployee.Remove(NewEmployee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
