using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RummageSale.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        [Display(Name = "Reschedule Start Date")]
        public DateTime? RescheduleStartDate { get; set; }
        [Display(Name = "Reschedule End Date")]
        public DateTime? RescheduleEndDate { get; set; }
        [ForeignKey("CatId")]
        public string CatId { get; set; }
        public Category category { get; set; }

    }
}
