using ClubMemberManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubMemberManagement.UI.ViewModels
{
    public class MemberOverviewVM
    {
        public List<Member> ClubMemberList { get; set; }

        public List<MembershipFee> Filters { get; set; }

        public MembershipFee SelectedFilter { get; set; }
    }
}
