using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly4.Models;

namespace Vidly4.Dtos
{
    //180817_1_20:00 dodanie pierwszego dto dla customer 
    public class CustomerDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
  
        public int Id { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


//        [Min18YearsIFAMember]
        //180812_1_17:25-----------------------------------------------
        public DateTime? Birthdate { get; set; }
    }
}