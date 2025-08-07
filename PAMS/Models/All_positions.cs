using System.ComponentModel.DataAnnotations;

namespace PAMS.Models
{
    public class All_positions
    {
        [Key]
        public int Position_Id { get; set; }
        public string Position_Name { get; set; }

        public virtual ICollection<All_users> Users { get; set; }
    }
}
