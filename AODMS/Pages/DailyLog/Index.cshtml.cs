using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AODMS.Pages.DailyLog
{
    public class IndexModel : PageModel
    {
        /* Create a context to allow CRUD database operations from the page. JG */
        private readonly DailyLogDbContext _db;

        /* Store DailyLog records from the database and allow iterations over them. JG */
        public IEnumerable<DailyLogSummary> DailyLogSummaries { get; set; }

        /* Instantiate the page model. JG */
        public IndexModel(DailyLogDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            /* Populate the DailyLog records from the database. JG */
            DailyLogSummaries = await _db.DailyLogSummaries.OrderBy(record => record.Date).ToListAsync();
        }
    }
}