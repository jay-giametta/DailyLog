using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AODMS.Models.DailyLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AODMS.Pages
{
    public class CreateModel : PageModel
    {
        /* Create a context variable to allow CRUD operations from the page. JG */
        private readonly DailyLogDbContext _db;

        /* Create a model binding for a log summary property to be used by the OnPost action method. JG */
        [BindProperty]
        public DailyLogSummary DailyLogSummary { get; set; }

        /* Store Location records from the database and allow iterations over them. JG */
        public IEnumerable<DailyLogLocation> DailyLogLocations { get; set; }

        /* Instantiate the page model. JG */
        public CreateModel(DailyLogDbContext db)
        {
            _db = db;
        }

        /* Do this when the page gets loaded. JG */
        public async Task OnGet()                                       
        {
            DailyLogLocations = await _db.DailyLogLocations.ToListAsync();      //Load the records from the Location table in the database
        }

         /* Do this when the form is submitted. JG */
        public async Task<IActionResult> OnPost()
        {
            /* Check if theres already an existing record with matching date/location. JG */
            int id;
            try
            {
                id = _db.DailyLogSummaries.Where(record => record.Unit == DailyLogSummary.Unit && record.Date == DailyLogSummary.Date).FirstOrDefault().Id;
            }
            catch (NullReferenceException)
            {
                await _db.DailyLogSummaries.AddAsync(DailyLogSummary);      //Prep the created DailyLog to save to the database
                await _db.SaveChangesAsync();                               //Save prepped changes
                id = DailyLogSummary.Id;
            }

            return Redirect(string.Format("./Entries?id={0}", id));     //Send the user to the correct shift entriesd DailyLog

        }
    }
}
 