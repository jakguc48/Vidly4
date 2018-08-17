using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly4.Models;
using MembershipType = Vidly4.Migrations.MembershipType;

namespace Vidly4.ViewModels
{
    public class CustomerFormViewModel
    {

        [Required(ErrorMessage = "Name jest polem wymaganym")]
        [StringLength(255)]
        public string Name { get; set; }

        public int? Id { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")] 
        public int? MembershipTypeId { get; set; }

        [Display(Name = "Day of birth")]
        [Min18YearsIFAMember]
        public DateTime? Birthdate { get; set; }

        //180812_1_17:34 Dodajemy obiekty, ktore będą nam potrzebne przy dodawaniu combobox z typami. Customer, do którego się odwołamy i typy
        //w przeciwienstwie do kursu tutaj musimy dodac odwołanie do Models
        public IEnumerable<Models.MembershipType> MembershipTypes { get; set; }
        //180812_1_17:34 -------------------------------------------------------------------------------------------------

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Name = customer.Name;
            Id = customer.Id;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
        }
    }
}