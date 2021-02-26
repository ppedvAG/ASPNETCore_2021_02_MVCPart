using ClubMemberManagement.UI.Data;
using ClubMemberManagement.UI.Models;
using ClubMemberManagement.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubMemberManagement.UI.Controllers
{
    public class MemberPaymentController : Controller
    {
        private readonly ClubMemberManagementDbContext _context;
        private DateTime currentDate = DateTime.Now;//new DateTime(2020, 2, 1);

        public MemberPaymentController(ClubMemberManagementDbContext context)
        {
            _context = context;
        }



        private int GetYearsFrom(DateTime start)
        {
            int years = currentDate.Year - start.Year;
            start = start.AddYears(years);
            if (currentDate.CompareTo(start) < 0) { years--; }
            return years;
        }

        private MembershipFee GetMembershipFee(int age, int yearsInClub)
        {
            // Ermittel alle vorhandenen Regeln
            IList<MembershipFee> allMembershipFee;

            //Gibt es Werte in der Spalte GültigAb/GültigBis
            //if (_context.MembershipFee.Any(n=>n.GiltAb.Value && n.GiltBis.Value))
            //{ 
            //allMembershipFee = _context.MembershipFee.ToList();
            //}

            

            allMembershipFee = _context.MembershipFee.Where(n => n.GiltAb <= currentDate && n.GiltBis > currentDate).ToList();

            IList<MembershipFee> validMembershipFees = new List<MembershipFee>();
            foreach (MembershipFee current  in allMembershipFee)
            {
                //Prüfe alle Regeln, ob diese mit den Parameter age und yearsInClubValide 


                bool isMembershipValid = false; 
                if (current.YearsInClub.HasValue)
                {
                    OperatorRule operationRule = (OperatorRule)current.YearsInClubRule;

                    switch (operationRule)
                    {
                        case OperatorRule.gleich:
                            isMembershipValid = current.YearsInClub == yearsInClub ? true : false;
                            break;
                        case OperatorRule.größer:
                            isMembershipValid = current.YearsInClub < yearsInClub ? true : false;
                            break;
                        case OperatorRule.größergleich:
                            isMembershipValid = current.YearsInClub <= yearsInClub ? true : false;
                            break;
                        case OperatorRule.kleiner:
                            isMembershipValid = current.YearsInClub > yearsInClub ? true : false;
                            break;
                        case OperatorRule.kleinergleich:
                            isMembershipValid = current.YearsInClub >= yearsInClub ? true : false;
                            break;

                    }
                }
                else if (current.Age.HasValue)
                {
                    OperatorRule operationRule = (OperatorRule)current.AgeRule;

                    switch (operationRule)
                    {
                        case OperatorRule.gleich:
                            isMembershipValid = current.Age == age ? true : false;
                            break;
                        case OperatorRule.größer:
                            isMembershipValid = current.Age < age ? true : false;
                            break;
                        case OperatorRule.größergleich:
                            isMembershipValid = current.Age <= age ? true : false;
                            break;
                        case OperatorRule.kleiner:
                            isMembershipValid = current.Age > age ? true : false;
                            break;
                        case OperatorRule.kleinergleich:
                            isMembershipValid = current.Age >= age ? true : false;
                            break;

                    }
                }
                else
                {
                    throw new Exception($"Regel mit der Id {current.Id} bist nicht initialisiert");
                }


                if (isMembershipValid)
                {
                    validMembershipFees.Add(current);
                }

            }

            if (validMembershipFees.Count == 0)
                throw new Exception("Es wurde keine Regel ermittelt");

            MembershipFee resultMembershipFee = validMembershipFees.OrderBy(n => n.Betrag).First();

            return resultMembershipFee;
        }

        public IActionResult Index()
        {
            //Ermittle aktuelles Jahr
            //Prüfe, ob alle Mitglieder einen Datensatz für das Jahr vorweisen können, wenn nein, Datensatz anlegen
            //Ergebis der View übergeben.
            int currentYear = currentDate.Year;

            // Lese alle Vereinsmitglieder aus
            var allMembers = _context.Member.ToList();

            //Gehe jedes Mitglied durch
            foreach (Member currentMember in allMembers)
            {
                

                //Prüfe, ob das Mitglied einen MemberPayment - Datensatz für das aktuelle Jahr verfügt
                if (!currentMember.MemberPayments.Any(n=>n.Year == currentYear))
                {
                    //Ermittlung der richtigen Bezahl Kategorie 
                    int memberAge = GetYearsFrom(currentMember.Geburtstag);
                    int yearInClub = GetYearsFrom(currentMember.Vereinseintritt);

                    MembershipFee membershipFee = GetMembershipFee(memberAge, yearInClub);


                    MemberPayment payment = new MemberPayment();
                    payment.BetragZuZahlen = membershipFee.Betrag;
                    payment.Member = currentMember;
                    payment.MemberId = currentMember.ID;
                    payment.IsPayed = false;
                    payment.MembershipFee = membershipFee;
                    payment.MembershipFeeId = membershipFee.Id;
                    payment.Year = currentYear;
                    //MemberPayment-Datensatz für das aktuelle Jahr wird angelegt. 

                    _context.MembershipPayment.Add(payment);
                }
                else
                {
                    MemberPayment currentMemberPayment = currentMember.MemberPayments.Single(n => n.Year == currentYear);



                    decimal summary = 0;
                    foreach (PaymentHistory payment in currentMemberPayment.PaymentHistory)
                    {
                        summary += payment.Payed;
                    }

                    currentMemberPayment.IsPayed = currentMemberPayment.BetragZuZahlen <= summary ? true : false;
                }
            }
            _context.SaveChanges();

            IList<MemberPayment> paymentsThisYear = _context.MembershipPayment.Where(n => n.Year == currentYear).ToList();

            IList<MemberPaymentVM> memberPaymentVMList = new List<MemberPaymentVM>();


            MemberPaymentVM memberPaymentVM = null;
            foreach (MemberPayment currentPayment in paymentsThisYear)
            {
                memberPaymentVM = new MemberPaymentVM();
                memberPaymentVM.MembershipPayment = currentPayment;
                memberPaymentVMList.Add(memberPaymentVM);
            }

            
            return View(memberPaymentVMList);
        }
    }
}
