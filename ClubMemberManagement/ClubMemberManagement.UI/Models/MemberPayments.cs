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

        public bool IsPayed { get; set; } = false;
        
        
        public int MembershipFeeId { get; set; }
        public int MemberId { get; set; }

        public decimal BetragZuZahlen { get; set; }


        //Navigation-Properties
        public virtual Member Member { get; set; }
        public virtual MembershipFee MembershipFee { get; set; }

        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }

        
    }


    public class PaymentHistory
    {
        public int Id { get; set; }

        public decimal Payed { get; set; }
        public DateTime PayedDate { get; set; }

        public int MemberPaymentId { get; set; }
        public virtual MemberPayment MemberPayments { get; set; }

    }
}
