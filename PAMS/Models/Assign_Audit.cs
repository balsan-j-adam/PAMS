using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class Assign_Audit
    {
        [Key]
        public int Audit_Assign_id { get; set; }
        public string Audit_Assign_Objective { get; set; }

        public int Audit_Assign_uni_id { get; set; }
        [ForeignKey("Audit_Assign_uni_id")]
        public virtual All_audit_universe Audit_Universe { get; set; }
        public int Audit_Assign_auditor_id { get; set; }
        [ForeignKey("Audit_Assign_auditor_id")]
        public virtual All_users All_Users { get; set; }
        public DateTime Audit_Assign_start_date { get; set; }
        public DateTime Audit_Assign_end_date { get; set; }
        public string Audit_status { get; set; } = "Planned";

        public virtual List<Audit_questions> Assigned_Questions { get; set; }
    }
}
