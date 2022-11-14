using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_WITH_EF.Data;
using CRUD_WITH_EF.Models;

namespace CRUD_WITH_EF.Pages
{
    public class EditModel : PageModel
    {
        private readonly CRUD_WITH_EF.Data.CRUD_WITH_EFContext _context;

        public EditModel(CRUD_WITH_EF.Data.CRUD_WITH_EFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NewEmployee NewEmployee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NewEmployee == null)
            {
                return NotFound();
            }

            var newemployee =  await _context.NewEmployee.FirstOrDefaultAsync(m => m.Empid == id);
            if (newemployee == null)
            {
                return NotFound();
            }
            NewEmployee = newemployee;
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

            _context.Attach(NewEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewEmployeeExists(NewEmployee.Empid))
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

        private bool NewEmployeeExists(int id)
        {
          return _context.NewEmployee.Any(e => e.Empid == id);
        }
    }
}
