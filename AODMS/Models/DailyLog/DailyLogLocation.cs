using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AODMS.Models.DailyLog
{
    public class DailyLogLocation
    {
        /* Location list for units that have Daily Logs. JG */
        [Key]
        public string Unit { get; set; }
    }
}
