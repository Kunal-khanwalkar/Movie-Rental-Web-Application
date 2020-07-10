using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Abe dumbo")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }

        [Display(Name = "Date of Birth")]
        [AgeRestrictionForMembers]
        public DateTime? birthdate { get; set; }
    }
}