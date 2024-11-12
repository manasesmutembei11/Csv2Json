using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv2Json
{
    public class ClaimRecord
    {
        public string Payroll { get; set; }
        public string ClaimantName { get; set; }
        public string IdNumber { get; set; }
        public DateTime? DateOfLoss { get; set; }
        public DateTime? IntimationDate { get; set; }

        public string BritamClaimNo { get; set; }
        public string NatureOfLoss { get; set; }
        public string Scheme { get; set; }
        public string NatureOfInjury {  get; set; }
        public string Service {  get; set; }
        public decimal? OriginalReserve {  get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? PaidToService { get; set; }
        public decimal? DoctorsFee { get; set; }
        public decimal? PTD {  get; set; }
        public decimal? TTD { get; set; }
        public decimal? OccupationalDisease { get; set; }
        public decimal? DeathFee {  get; set; }
        public decimal? MedicalFee { get; set;}
        public decimal? CurrentOs {  get; set; }
        public decimal? IncurredLessDF { get; set; }
        public decimal? IncurredAmount { get; set; }
        public string DocumentationStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string EndToEndTAT {  get; set; }

        public DateTime? DateFullyDocumented { get; set; }
        public string DocumentationTAT { get; set; }
        public DateTime? DvIssueDate { get; set; }
        public string DvIssueTAT { get; set; }
        public DateTime? DvReceiveDate { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DateRemitted { get; set; }
        public string TATFinance { get; set; }
        public string PaymentRequisitionNo { get; set; }
        public string Station {  get; set; }


    }
}
