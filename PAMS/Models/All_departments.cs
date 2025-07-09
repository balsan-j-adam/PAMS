using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class All_departments
    {
        [Key]
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }


        public virtual ICollection<All_users> Users { get; set; }
    }
}
