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
    public class IndexModel : PageModel
    {
        private readonly CRUD_WITH_EF.Data.CRUD_WITH_EFContext _context;

        public IndexModel(CRUD_WITH_EF.Data.CRUD_WITH_EFContext context)
        {
            _context = context;
        }

        public IList<NewEmployee> NewEmployee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.NewEmployee != null)
            {
                NewEmployee = await _context.NewEmployee.ToListAsync();
            }
        }
    }
}
