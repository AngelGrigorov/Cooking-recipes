using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReceptionsListProject.Models;

    public class ReceptionsListProjectContext : DbContext
    {
        public ReceptionsListProjectContext (DbContextOptions<ReceptionsListProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ReceptionsListProject.Models.Reception> Reception { get; set; }
    }
