using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClubMemberManagement.UI.Models;

namespace ClubMemberManagement.UI.Data
{
    public class ClubMemberManagementDbContext : DbContext
    {
        public ClubMemberManagementDbContext (DbContextOptions<ClubMemberManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClubMemberManagement.UI.Models.Member> Member { get; set; }
        public DbSet<ClubMemberManagement.UI.Models.MembershipFee> MembershipFee { get; set; }
        public DbSet<ClubMemberManagement.UI.Models.MemberPayment> MembershipPayment { get; set; }
        public DbSet<ClubMemberManagement.UI.Models.PaymentHistory> PaymentHistory { get; set; }
    }
}
