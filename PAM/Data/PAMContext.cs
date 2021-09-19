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
        public DbSet<PAM.Models.IMDBItem> IMDBItem { get; set; }
        public DbSet<PAM.Models.IMDBActor> IMDBActor { get; set; }
        public DbSet<PAM.Models.IMDBCompany> IMDBCompany { get; set; }
        public DbSet<PAM.Models.IMDBDirector> IMDBDirector { get; set; }
        public DbSet<PAM.Models.IMDBGenre> IMDBGenre { get; set; }
        public DbSet<PAM.Models.IMDBItemsList> IMDBItemsList { get; set; }
        public DbSet<PAM.Models.IMDBWriter> IMDBWriter { get; set; }

    }
}
