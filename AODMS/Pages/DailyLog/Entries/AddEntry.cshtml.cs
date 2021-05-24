using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AODMS.Pages.DailyLog.Entries
{
    public class AddEntryModel : PageModel
    {
        /* Create a context variable to allow CRUD operations from the page. JG */
        private readonly DailyLogDbContext _db;

        /* Create a model binding to be used by the OnPost action method. JG */
        [BindProperty]
        public DailyLogEntry DailyLogEntry { get; set; }

        [BindProperty]
        /* Store the id parameter to link log entries to the correct log. JG */
        public int LogId { get; set; }

        /* Instantiate the page model. JG */
        public AddEntryModel(DailyLogDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            /* Set the logid with the the passed id parameter. JG */
            LogId = id;
        }

        public async Task<IActionResult> OnPost()
        {
            /* Fill in hidden values for the log entry. JG */
            DailyLogEntry.CreateTime = DateTime.Now;

            await _db.DailyLogEntries.AddAsync(DailyLogEntry);                                      //Prep the log entry to save to the database

            await _db.SaveChangesAsync();                                                           //Save prepped changes
        
            return Redirect(string.Format(".?id={0}", DailyLogEntry.LogSummaryId));                 //Send the user back to the correct log entry page
        }
    }
}