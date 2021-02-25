using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtstag { get; set; }
        public DateTime Vereinseintritt { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }


        public ICollection<MemberPayment> MemberPayments { get; set; }
    }
}
