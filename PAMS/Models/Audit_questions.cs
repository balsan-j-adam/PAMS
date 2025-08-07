using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class Audit_questions
    {
        [Key]
        public int Audit_Questions_Id { get; set; } 

        public int? AuditId { get; set; } 
        [ForeignKey("AuditId")]
        public virtual Assign_Audit Audit { get; set; }

        public int? Checklist_Id { get; set; } 
        [ForeignKey("Checklist_Id")]
        public virtual Add_checklists Checklist { get; set; }
    }
}
