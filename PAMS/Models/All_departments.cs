using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class All_departments
    {
        [Key]
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }


        public virtual ICollection<All_users> Users { get; set; }

        public virtual ICollection<All_audit_universe> AuditsUnivers { get; set; }

        public virtual ICollection<Add_checklists> Checklists { get; set; }
     }
}
