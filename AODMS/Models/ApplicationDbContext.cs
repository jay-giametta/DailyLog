using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AODMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        /* Default database context for use with AODMS DB. JG */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        /* Used for DailyLog table references by the DailyLog index. JG */
        public DbSet<DailyLog> DailyLog { get; set; }
    }
}
