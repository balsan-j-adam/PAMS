using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAMS.Models
{
    public class Add_checklists
    {
        [Key]
        public int Checklist_id { get; set; }
        public string Checklist_question { get; set; }

        public int Checklist_dept_id { get; set; }
        [ForeignKey("Checklist_dept_id")]
        public virtual All_departments Departments { get; set; }
    }
}
