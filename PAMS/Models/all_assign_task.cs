using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAMS.Models
{
    public class all_assign_task
    {
        [Key]
        public int all_task_id { get; set; }

        public DateTime Assigned_date { get; set; } = DateTime.Now;
        public DateTime Due_date { get; set; }
        public int task_Audit_Id { get; set; }
        [ForeignKey("task_Audit_Id")]
        public virtual Assign_Audit Assign_Audits { get; set; }
        public int task_QuestionId { get; set; }
        [ForeignKey("task_QuestionId")]
        public virtual Audit_questions Audit_Questionss { get; set; }
        public int task_Assign_AuditorId { get; set; }
        [ForeignKey("task_Assign_AuditorId")]
        public virtual All_users All_userss { get; set; }

        public virtual ICollection<Task_response> Tasks { get; set; }
       







      
    }

 
}
