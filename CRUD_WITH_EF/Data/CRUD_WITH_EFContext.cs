using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_WITH_EF.Models;

namespace CRUD_WITH_EF.Data
{
    public class CRUD_WITH_EFContext : DbContext
    {
        public CRUD_WITH_EFContext (DbContextOptions<CRUD_WITH_EFContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_WITH_EF.Models.NewEmployee> NewEmployee { get; set; } = default!;
    }
}
