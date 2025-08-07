using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAMS.Database;
using PAMS.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PAMS.Controllers
{
    public class AuditorController : Controller
    {

        private readonly string _uploadsFolderPath;
        private readonly Mycontext _context;
        public AuditorController(IWebHostEnvironment env, Mycontext context)
        {
            _uploadsFolderPath = Path.Combine(env.WebRootPath, "allimages");
            _context = context;
        }


        
     
       

        public IActionResult Assign_subtask()
        {
            

            return View();
        }

        public IActionResult Assigned_Audits()
        {
            var id = HttpContext.Session.GetInt32("Id");

            var data = _context.Audit_Assigns_all
       .Where(o => o.Audit_Assign_auditor_id == id)
       .Include(o => o.All_Users)
           .ThenInclude(a => a.Positions)
       .Include(k => k.Audit_Universe.Departments)
       .Include(i => i.Assigned_Questions)
           .ThenInclude(q => q.Checklist)
       .ToList();

            return View(data);
        }


        public IActionResult Assign_task(int id)
        {
            var all = new All_Model_BInds
            {
                all_Users_list=_context.All_users.Where(c=>c.Positions.Position_Name=="Auditee").ToList(),
               audit_Assign=_context.Audit_Assigns_all.FirstOrDefault(c=>c.Audit_Assign_id==id),
               audit_Questions_list=_context.Audit_questions.Include(p=>p.Checklist).Where(c=>c.AuditId==id).ToList(),
              

            };
            return View(all);
        }
        [HttpPost]
        public IActionResult Assign_task(All_Model_BInds data)
        {
            var all =data.all_task_simple;
            if (all != null)
            {
                _context.Audit_tasks.Add(all);
                _context.SaveChanges();
            }
            if (data.AssignedUserIds != null)

            {

                foreach (var userId in data.AssignedUserIds)
                {
                    var userExists = _context.All_users.Any(u => u.User_id == userId);
                    if (!userExists)
                    {
                        throw new Exception($"Invalid UserId: {userId}");
                    }
                    var assign = new Task_response
                    {
                        Response_TaskId = all.all_task_id,
                        Response_AuditeeId = userId,
                        
                    };
                    _context.task_Responses.Add(assign);
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Kanban_board");


            return View();
        }

        public IActionResult All_tasks()
        {

            var all = _context.task_Responses
      .Include(c => c.Task)
          .ThenInclude(d => d.Assign_Audits)
      .Include(c => c.Task)
          .ThenInclude(d => d.Audit_Questionss)
              .ThenInclude(q => q.Checklist)
      .Include(c=>c.Task.All_userss) 
      .Where(c => c.Response_AuditeeId == HttpContext.Session.GetInt32("Id"))
      .ToList();
            return View(all);
        }
        public IActionResult Kanban_board() {

            var all = _context.task_Responses
     .Include(c => c.Task)
         .ThenInclude(d => d.Assign_Audits)
     .Include(c => c.Task)
         .ThenInclude(d => d.Audit_Questionss)
             .ThenInclude(q => q.Checklist)
     .Include(c => c.Auditee).ToList();
            return View(all);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTaskStatus([FromBody] TaskStatusUpdateModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.status))
                return BadRequest("Invalid data");

            // Task_response table me id ke basis par record nikaalna
            var task = _context.task_Responses.FirstOrDefault(t => t.Response_Id == model.id);

            if (task == null)
                return NotFound("Task not found");

            // Status ko update karna
            task.Task_Status = model.status;

            // Save karna
            _context.SaveChanges();

            return Ok("Task status updated successfully");
        }
        public IActionResult Start_task(int id )
        {
            var all = _context.task_Responses.FirstOrDefault(d => d.Response_Id == id);
            if(all != null)
            {
                all.Task_Status = "Working";
                _context.SaveChanges();

            }

            var data = new All_Model_BInds
            {
                task_Response_Img=new Task_response_img(),
                task_Response = all,

            };

            return View(data);
        }
        [HttpPost]
        public IActionResult Start_task(All_Model_BInds model)
        {
            if (model.task_Response_Img.Response_EvidenceFilePath != null && model.task_Response_Img.Response_EvidenceFilePath.Length > 0)
            {
                if (model.task_Response_Img?.Response_EvidenceFilePath != null)
                {
                    Console.WriteLine("Image Name: " + model.task_Response_Img.Response_EvidenceFilePath.FileName);
                    Console.WriteLine("Image Length: " + model.task_Response_Img.Response_EvidenceFilePath.Length);
                }
                else
                {
                    Console.WriteLine("Image is not available in the model.");
                }
                if (!Directory.Exists(_uploadsFolderPath))
                {
                    Directory.CreateDirectory(_uploadsFolderPath);
                }

                var filename = Path.GetFileName(model.task_Response_Img.Response_EvidenceFilePath.FileName);
                var filepath = Path.Combine(_uploadsFolderPath, filename);


                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    model.task_Response_Img.Response_EvidenceFilePath.CopyTo(stream);
                }
                var response = _context.task_Responses.FirstOrDefault(r => r.Response_Id == model.task_Response_Img.Response_Id);
                if (response != null)
                {
                    response.Response_date=DateTime.Now;
                    response.Response_EvidenceFilePath = filename;
                    response.Response_Finding = model.task_Response_Img.Response_Finding;
                    response.Task_Status = "Completed";

                    _context.SaveChanges();
                }

                return RedirectToAction("All_tasks");
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
