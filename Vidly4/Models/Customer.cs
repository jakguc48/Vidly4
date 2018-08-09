using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //180809 22:23 dodajemy odwołanie do nowostworzonej klasy. Tak zwana navigation property. Pozwala nam podać oba obiekty razem. Coś jak relacja albo join
        public MembershipType MembershipType { get; set; }
        //180809 22:23 można też dodać tylko foreign key, konwencja uznaje taki zapis
        public byte MembershipTypeId { get; set; }  
    }
}