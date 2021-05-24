using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AODMS.Pages.DailyLog.Entries
{
    public class VerifyEntryModel : PageModel
    {
        /* Create a context variable to allow CRUD operations from the page. JG */
        private readonly DailyLogDbContext _db;

        /* Create a model binding to be used by the OnGet action method. JG */
        [BindProperty]
        public DailyLogSummary DailyLogSummary { get; set; }

        /* Instantiate the page model. JG */
        public VerifyEntryModel(DailyLogDbContext db)
        {
            _db = db;
        }

        /* Instantiate DailyLogEntry with the record info corresponding to the given id parameter. JG */
        public async Task<IActionResult> OnGet(int id, string certifier)
        {
            DailyLogSummary = await _db.DailyLogSummaries.FindAsync(id);        //Find the record that corresonds to the given id parameter. JG

            DailyLogSummary.CertifiedBy = certifier;                            //Update the record with the given entry edit. JG

            await _db.SaveChangesAsync();                                       //Push changes to the database. JG

            return Redirect(string.Format(".?id={0}", id));                     //Return to the previous daily log page. JG
        }

    }
}