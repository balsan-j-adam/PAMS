using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAMS.Models
{
    public class All_users
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set; }

        public string User_email { get; set; }
        public string User_pass { get; set; }

        public int? User_department_id { get; set; }
        [ForeignKey("User_department_id")]
        public virtual All_departments Departments { get; set; }

        public int? User_Position_id { get; set; }
        [ForeignKey("User_Position_id")]
        public virtual All_positions Positions { get; set; }
        public string User_Role { get; set; }

    }
}
