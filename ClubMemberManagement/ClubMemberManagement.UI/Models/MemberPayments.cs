using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.Models
{
    public class MemberPayment
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public bool IsPayed { get; set; }
        public ICollection<PaymentHistory> PaymentHistory { get; set; }
        
        public int MembershipFeeId { get; set; }
        public MembershipFee MembershipFee { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }


    public class PaymentHistory
    {
        public int Id { get; set; }

        public decimal Payed { get; set; }
        public DateTime PayedDate { get; set; }

        public int MemberPaymentId { get; set; }
        public MemberPayment MemberPayments { get; set; }

    }
}
