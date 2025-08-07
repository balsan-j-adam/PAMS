using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAMS.Models
{
    public class All_audit_universe
    {
        [Key]
        public int Audit_Universe_Id { get; set; }

        public int Audit_Universe_Dept_Id { get; set; }
        [ForeignKey("Audit_Universe_Dept_Id")]
        public virtual All_departments Departments { get; set; }
        public int Audit_Universe_Risk_Id { get; set; }
        [ForeignKey("Audit_Universe_Risk_Id")]
        public virtual Risk_Categories Risks { get; set; }
        public string Audit_Universe_Impact { get; set; }
        public string Audit_Universe_likelihood { get; set; }   

        public int Audit_Universe_Risk_ratio { get; set; }
        public string Audit_Universe_Status { get; set; } = "pending";






    }
}
