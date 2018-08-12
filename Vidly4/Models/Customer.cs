using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataHandler;
using Newtonsoft.Json;

namespace Vidly4.Models
{
    public class Customer
    {
        //180809 22:56 dodajemy tutaj oznaczenie sprawiające, że name nie bedize już nullable. możnemy tez dodać mx liczbe znaków
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //180809 22:23 dodajemy odwołanie do nowostworzonej klasy. Tak zwana navigation property. Pozwala nam podać oba obiekty razem. Coś jak relacja albo join
        public MembershipType MembershipType { get; set; }
        //180809 22:23 można też dodać tylko foreign key, konwencja uznaje taki zapis
        public byte MembershipTypeId { get; set; } 
        public DateTime? Birthdate { get; set; }


    }
}