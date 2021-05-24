using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AODMS.Pages.DailyLog.Entries
{
    public class EditEntryModel : PageModel
    {
        /* Create a context variable to allow CRUD operations from the page. JG */
        private readonly DailyLogDbContext _db;

        /* Instantiate the local context variable. JG */
        public EditEntryModel(DailyLogDbContext db)
        {
            _db = db;
        }

        /* Create a model binding to be used by the OnGet action method. JG */
        [BindProperty]
        public DailyLogEntry DailyLogEntry { get; set; }

        /* Instantiate DailyLogEntry with the record info corresponding to the given id parameter. JG */
        public async Task OnGet(int id)
        {
            DailyLogEntry = await _db.DailyLogEntries.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                
                var DailyLogEntryDb = await _db.DailyLogEntries.FindAsync(DailyLogEntry.Id);            //Get an object for the record that will be updated in the database

                DailyLogEntryDb.Entry = DailyLogEntry.Entry;                                            //Update the record with the given entry edit

                await _db.SaveChangesAsync();                                                           //Push changes to the database

                return Redirect(string.Format(".?id={0}", DailyLogEntry.LogSummaryId));                 //Send the user back to the correct log entry page
            }
            else
            {
                return Page();                                                                          //Return to the edit page if model is invalid.
            }
        }
    }
}