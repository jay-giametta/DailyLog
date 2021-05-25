using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AODMS.Pages.DailyLog.Entries
{
    public class InvalidateEntryModel : PageModel
    {
        /* Create a context variable to allow CRUD operations from the page. JG */
        private readonly DailyLogDbContext _db;

        /* Create a property to store daily log summary info. JG */
        public DailyLogSummary DailyLogSummary { get; set; }

        /* Instantiate the page model. JG */
        public InvalidateEntryModel(DailyLogDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            DailyLogSummary = await _db.DailyLogSummaries.FindAsync(id);        //Find the record that corresonds to the given id parameter. JG

            DailyLogSummary.ValidatedBy = null;                                 //Update the record with the given entry edit. JG

            await _db.SaveChangesAsync();                                       //Push changes to the database. JG

            return Redirect(string.Format(".?id={0}", id));                     //Return to the previous daily log page. JG
        }
    }
}