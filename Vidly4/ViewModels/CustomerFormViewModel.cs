using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly4.Models;
using MembershipType = Vidly4.Migrations.MembershipType;

namespace Vidly4.ViewModels
{
    public class CustomerFormViewModel
    {
        //180812_1_17:34 Dodajemy obiekty, ktore będą nam potrzebne przy dodawaniu combobox z typami. Customer, do którego się odwołamy i typy
        //w przeciwienstwie do kursu tutaj musimy dodac odwołanie do Models
        public IEnumerable<Models.MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        //180812_1_17:34 -------------------------------------------------------------------------------------------------
    }
}