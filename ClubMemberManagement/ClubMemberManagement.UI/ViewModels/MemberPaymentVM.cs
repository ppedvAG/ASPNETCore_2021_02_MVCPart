using ClubMemberManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.ViewModels
{
    public class MemberPaymentVM
    {
        public virtual MemberPayment MembershipPayment { get; set; }
        public decimal BezahlterBetrag 
        { 
            get
            {
                if (MembershipPayment == null)
                    return 0;

                if (MembershipPayment.PaymentHistory.Count == 0)
                    return 0;

                decimal summaryPayment = 0;
                
                foreach (PaymentHistory paymentHistory in MembershipPayment.PaymentHistory)
                {
                    summaryPayment += paymentHistory.Payed;
                }

                return summaryPayment;
            }
        }
    }
}
