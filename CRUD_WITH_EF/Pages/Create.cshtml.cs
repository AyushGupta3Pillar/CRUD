using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD_WITH_EF.Data;
using CRUD_WITH_EF.Models;

namespace CRUD_WITH_EF.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CRUD_WITH_EF.Data.CRUD_WITH_EFContext _context;

        public CreateModel(CRUD_WITH_EF.Data.CRUD_WITH_EFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewEmployee NewEmployee { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NewEmployee.Add(NewEmployee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
