namespace PAMS.Models
{
    public class All_Model_BInds
    {
       public All_users all_Users { get; set; }
        public All_audit_universe all_Audits_Universe { get; set; }
     
        public Add_checklists all_Checklists { get; set; }
        public Assign_Audit audit_Assign { get; set; }
        public Task_response task_Response { get; set; }
       public Task_response_img task_Response_Img { get; set; }
        public all_assign_task all_task_simple {  get; set; }
        public List<all_assign_task> all_Assign_Tasks { get; set; }
        public List<int> AssignedUserIds { get; set; } = new List<int>();
        public List<Audit_questions> audit_Questions_list { get; set; }
        public List<Assign_Audit> assign_Audit_list { get; set; }
        public List<Add_checklists> all_Checklist_list { get; set; }
        public List<Checklist_Tick> tick_Checklist_list { get; set; }
        public List<All_users> all_Users_list { get; set; }

        public List<Risk_Categories> Risk_Categories { get; set; }
        public List<All_positions> all_Positions_list { get; set; }

        public List<All_departments> all_Departments_list { get; set; }

    }
}
