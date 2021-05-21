using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AODMS.Models.DailyLog
{
    public class DailyLogDbContext : DbContext
    {
        /* Default database context for use with AODMS DB. JG */
        public DailyLogDbContext(DbContextOptions<DailyLogDbContext> options) : base(options) { }

        /* Stores daily log summary data. JG */
        public DbSet<DailyLogSummary> DailyLogSummaries { get; set; }

        /* Stores unit locations to segregate daily logs. JG */
        public DbSet<DailyLogLocation> DailyLogLocations { get; set; }

        /* Stores log entries for each daily log. JG */
        public DbSet<DailyLogEntry> DailyLogEntries { get; set; }
    }

}
