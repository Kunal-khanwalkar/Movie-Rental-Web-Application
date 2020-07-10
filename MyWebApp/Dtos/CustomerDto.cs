using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MyWebApp.Models;

namespace MyWebApp.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }        
        
        public byte MembershipTypeID { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[AgeRestrictionForMembers]
        public DateTime? birthdate { get; set; }
    }
}