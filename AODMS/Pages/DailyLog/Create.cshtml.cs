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

        /* Instantiate the local context variable. JG */
        public CreateModel(DailyLogDbContext db)
        {
            _db = db;
        }

        /* Create a model binding to be used by the OnPost action method. JG */
        [BindProperty]
        public DailyLogSummary DailyLogSummary { get; set; }

        /* Store Location records from the database and allow iterations over them. JG */
        public IEnumerable<DailyLogLocation> DailyLogLocations { get; set; }

        /* Do this when the page gets loaded. JG */
        public async Task OnGet()                                       
        {
            DailyLogLocations = await _db.DailyLogLocations.ToListAsync();      //Load the records from the Location table in the databse
        }

         /* Do this when the form is submitted. JG */
        public async Task<IActionResult> OnPost()
        {
            /* Don't create records for invalid model states. JG */
            if (!ModelState.IsValid)
            {
                DailyLogLocations = await _db.DailyLogLocations.ToListAsync();  //Load the records from the Location table in the database
                return Page();                                                  //Send the user back to this page on non-valid state
            }
            else
            {
                /* Check if theres already an existing record with matching date/location. JG */
                int id;
                try
                {
                    id = _db.DailyLogSummaries.Where(record => record.Location == DailyLogSummary.Location && record.Date == DailyLogSummary.Date).FirstOrDefault().Id;
                }
                catch (NullReferenceException)
                {
                    await _db.DailyLogSummaries.AddAsync(DailyLogSummary);      //Prep the created DailyLog to save to the database
                    await _db.SaveChangesAsync();                               //Save prepped changes
                    id = DailyLogSummary.Id;
                }

                return Redirect(string.Format("./Entries?id={0}",id));     //Send the user to the correct shift entriesd DailyLog
            }
        }
    }
}
 