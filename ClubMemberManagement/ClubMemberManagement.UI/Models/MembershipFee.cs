using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.Models
{
    public class MembershipFee
    {
        public int Id { get; set; }

        public string Bezeichnung { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal Betrag { get; set; }

        public int? Age { get; set; }
        public OperatorRule? AgeRule { get; set; }

        public int? YearsInClub { get; set; }
        public OperatorRule? YearsInClubRule { get; set; }

        public virtual ICollection<MemberPayment> MemberPayments { get; set; }
    }
    public enum OperatorRule { gleich=0, kleiner=1, größer=2, kleinergleich=3, größergleich=4 }
}
