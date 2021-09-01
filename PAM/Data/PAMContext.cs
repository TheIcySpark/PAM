using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAM.Models;

namespace PAM.Data
{
    public class PAMContext : DbContext
    {
        public PAMContext (DbContextOptions<PAMContext> options)
            : base(options)
        {
        }

        public DbSet<PAM.Models.User> User { get; set; }
    }
}
