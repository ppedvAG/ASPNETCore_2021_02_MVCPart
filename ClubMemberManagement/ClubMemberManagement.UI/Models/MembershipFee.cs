using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.Models
{
    public class MembershipFee
    {
        public int Id { get; set; }

        public string Bezeichnung { get; set; }
        public decimal Betrag { get; set; }


        public ICollection<MemberPayment> MemberPayments { get; set; }
    }
}
