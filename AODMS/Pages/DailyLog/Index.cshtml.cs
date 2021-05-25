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

        /* Store Location records from the database and allow iterations over them. JG */
        public IEnumerable<DailyLogLocation> DailyLogLocations { get; set; }

        /* Instantiate the page model. JG */
        public IndexModel(DailyLogDbContext db)
        {
            _db = db;
        }

        public string myUnit = "All";

        public async Task OnGet(string unit)
        {
            /* Load the records from the Location table in the database. JG */
            DailyLogLocations = await _db.DailyLogLocations.ToListAsync();      

            /* Populate the DailyLog records from the database. JG */
            if (unit != null)
            {
                myUnit = unit;

                /* Allow loading a dashboard with a specific location. JG */
                DailyLogSummaries = await _db.DailyLogSummaries.Where(record => record.Unit == unit).OrderBy(record => record.Date).ToListAsync();
            }
            else
            {               
                DailyLogSummaries = await _db.DailyLogSummaries.OrderBy(record => record.Date).ToListAsync();
            }
            
        }
    }
}