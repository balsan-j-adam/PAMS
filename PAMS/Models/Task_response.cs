using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class Task_response
    {
        [Key]
        public int Response_Id { get; set; }

        public int Response_TaskId { get; set; } // Link to Audit_Task
        [ForeignKey("Response_TaskId")]
        public virtual all_assign_task Task { get; set; }

        public int Response_AuditeeId { get; set; } // User who got the task
        [ForeignKey("Response_AuditeeId")]
        public virtual All_users Auditee { get; set; }

        public string? Response_Finding { get; set; }
        public string? Response_EvidenceFilePath { get; set; }
        public DateTime? Response_date { get; set; }

        public string Task_Status { get; set; } = "Pending";
    }
    public class TaskStatusUpdateModel
    {
        public int id { get; set; }
        public string status { get; set; }
    }

    public class Task_response_img
    {
        [Key]
        public int Response_Id { get; set; }

        public int Response_TaskId { get; set; } // Link to Audit_Task
        [ForeignKey("Response_TaskId")]
        public virtual all_assign_task Task { get; set; }

        public int Response_AuditeeId { get; set; } // User who got the task
        [ForeignKey("Response_AuditeeId")]
        public virtual All_users Auditee { get; set; }

        public string? Response_Finding { get; set; }
        public IFormFile? Response_EvidenceFilePath { get; set; }
        public DateTime? Response_date { get; set; }
        public string Task_Status { get; set; } = "Pending";
    }
}
