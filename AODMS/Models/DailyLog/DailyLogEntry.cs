using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AODMS.Models.DailyLog
{
    public class DailyLogEntry
    {
        /* Autogenerate Ids. JG */
        [Key]
        public int Id { get; set; }

        /* Foreign Key: The Id of the LogSummary that this entry corresponds to. JG */
        [Required]
        public int LogSummaryId { get; set; }

        /* A timestamp showing when the entry was logged. JG */
        [Required]
        public DateTime CreateTime { get; set; }

        /* The user that created the entry. JG */
        [Required]
        public string CreateUser { get; set; }

        /* The text of the log entry. JG */
        [Required]
        public string Entry { get; set; }
    }
}
