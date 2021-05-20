using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AODMS.Models
{
    public class DailyLog
    {
        /* Autogenerate Ids. JG */
        [Key]
        public int Id { get; set; }

        /* Equivalent to unit/PAS. Can have more than one location per base. JG */
        [Required]
        public string Location { get; set; }

        /* Log creation date. JG */
        [Required]
        public string Date { get; set; }
    }
}
