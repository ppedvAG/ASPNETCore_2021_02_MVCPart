using ClubMemberManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.ViewModels
{
    public class CreatePaymentHistoryVM
    {
        public PaymentHistory Payment { get; set; }
        public int MemberPaymentId { get; set; }
    }
}
