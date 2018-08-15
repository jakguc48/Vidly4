using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.Owin.Security.DataHandler;

namespace Vidly4.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        //180815_3_17:18 dodajemy stateczyn pola readonly zeby się odnośić do typów subskrybcji (w Model/Min18YearsIFAMember.cs) nie po liczbach tylko po nazwach - czytelniejszy kod  
        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo= 1;
        public static readonly int Monthly = 2;
        public static readonly int Quaterly = 3;
        public static readonly int Yearly = 4;
    }
}