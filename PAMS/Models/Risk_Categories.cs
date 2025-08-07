using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class Risk_Categories
    {
        [Key]
        public int Risk_Id { get; set; }
        public string Risk_Category_Name { get; set; }

        public virtual ICollection<All_audit_universe> AuditsUnivers { get; set; }
    }
}
