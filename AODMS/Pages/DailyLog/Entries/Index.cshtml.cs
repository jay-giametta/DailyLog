using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AODMS.Pages.DailyLog.Entries
{
    public class IndexModel : PageModel
    {
        /* Create a context to allow CRUD database operations from the page. JG */
        private DailyLogDbContext _db;

        /* Instantiate the local database context. JG */
        public IndexModel(DailyLogDbContext db)
        {
            _db = db;
        }

        /* Store DailyLog records from the database and allow iterations over them. JG */
        public IEnumerable<DailyLogEntry> DailyLogEntries { get; set; }

        /* Store the log summary that corresponds to the id parameter that must be passed to this page. JG */
        public DailyLogSummary DailyLogSummary { get; set; }

        /* Store the id parameter to link log entries to the correct log. JG */
        public int LogId { get; set; }

        public async Task OnGet(int id)
        {
            /* Set the logid with the the passed id parameter. JG */
            LogId = id;

            /* Find the log summary that corresponds to the passed id parameter. JG */
            DailyLogSummary = await _db.DailyLogSummaries.FindAsync(id);

            /* Find the log entries that correspond to the passed id parameter. JG */
            DailyLogEntries = await _db.DailyLogEntries.Where(record => record.LogSummaryId == id).OrderBy(record => record.CreateTime).ToListAsync();
        }
    }
}