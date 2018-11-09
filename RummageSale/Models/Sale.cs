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
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Reschedule Start Date")]
        public DateTime? RescheduleStartDate { get; set; }
        [Display(Name = "Reschedule End Date")]
        public DateTime? RescheduleEndDate { get; set; }
        public string Description { get; set; }
        [Display(Name = "Price Range")]
        public string PriceRange { get; set; }   
        public string Picture { get; set; }
 
      

        

        [ForeignKey("RummageUser")]
        public int UserId { get; set; }
        public RummageUser RummageUser { get; set; }
       

    }
}
