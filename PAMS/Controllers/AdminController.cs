using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PAMS.Database;
using PAMS.Models;



namespace PAMS.Controllers
{
    public class AdminController : Controller
    {

        private readonly string _uploadsFolderPath;
        private readonly Mycontext _context;
        public AdminController(IWebHostEnvironment env, Mycontext context)
        {
            _uploadsFolderPath = Path.Combine(env.WebRootPath, "allimages");
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Audit Assignment Start
        public IActionResult All_Audits()
        {
            var all = _context.Audit_Assigns_all.Include(c=>c.Audit_Universe).ThenInclude(b=>b.Departments).Include(x=>x.Assigned_Questions).ThenInclude(q=>q.Checklist).ToList();
            return View(all);
        }

        public IActionResult Audit_Assign()
        {
            var all = _context.All_Audit_universes.Include(u => u.Departments).Include(i => i.Risks).Where(c=>c.Audit_Universe_Status=="pending").ToList();
           
            return View(all);
        }
       

             public IActionResult Add_Assign_audit(int id)
        {
            var audit = _context.All_Audit_universes.Include(u => u.Departments).Include(i => i.Risks).FirstOrDefault(c => c.Audit_Universe_Id == id);

            var deptId = audit.Audit_Universe_Dept_Id;
            var checklist = _context.Add_checklists.Where(c => c.Checklist_dept_id == deptId).Select(c => new Checklist_Tick
            {
                Audit_Check_Id = c.Checklist_id,
                Audit_Check_Question = c.Checklist_question,
                Audit_Check_IsSelected = true
            }).ToList();
            var all = new All_Model_BInds
            {
                all_Audits_Universe = audit,
                audit_Assign=new Assign_Audit(),

                all_Users_list=_context.All_users.Where(c=>c.Positions.Position_Name=="Auditor").ToList(),
               tick_Checklist_list=checklist


            };
            return View(all);

        }

        [HttpPost]

        public  IActionResult Add_Assign_audit(All_Model_BInds data)
        {

            
            _context.Audit_Assigns_all.Add(data.audit_Assign);
             _context.SaveChanges();

            var universe = _context.All_Audit_universes
    .FirstOrDefault(u => u.Audit_Universe_Id == data.audit_Assign.Audit_Assign_uni_id);

            if (universe != null)
            {
                universe.Audit_Universe_Status = "working";
                _context.All_Audit_universes.Update(universe); // optional — EF tracks changes
            }

            foreach (var q in data.tick_Checklist_list)
            {
                if (q.Audit_Check_IsSelected)
                {
                    _context.Audit_questions.Add(new Audit_questions
                    {
                        AuditId = data.audit_Assign.Audit_Assign_id,
                        Checklist_Id = q.Audit_Check_Id
                    });
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        // Audit Assignment End
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(All_users user )
        {

            var data = _context.All_users.Include(u=>u.Positions).FirstOrDefault(u => u.User_email == user.User_email);
            if(data != null && data.User_pass == user.User_pass)
            {
                HttpContext.Session.SetString("Role", data.User_Role);

                HttpContext.Session.SetInt32("Id", data.User_id);

                if (data.User_Role == "Admin")
                {

                    return RedirectToAction("Index");
                }
                if (data.User_Role == "User" && data.Positions.Position_Name == "Auditor")
                {
                    HttpContext.Session.SetString("Position", data.Positions.Position_Name);
                    return RedirectToAction("Assigned_Audits", "Auditor");
                }
                if (data.User_Role == "User" && data.Positions.Position_Name == "Auditee")
                {
                    HttpContext.Session.SetString("Position", data.Positions.Position_Name);
                    return RedirectToAction("All_tasks", "Auditor");
                }


            }

            return View();
        }


        public IActionResult AdminIndex()
        {
           
            return View();
        }


        public async Task<IActionResult> Create()
        {
            
            return View();
        }

       

        public async Task<IActionResult> Edit(string id)
        {
           

            return View();
        }

       


        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
           

            return View();
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
           
            

            return View();
        }


        // CRUD DEPARTMENTS START


        public async Task<IActionResult> All_Departments()
        {
             var all = _context.All_departments.ToList();


            return View(all);
        }

        public  async Task<IActionResult> Add_Departments() { 

           
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add_Departments(All_departments departments)
        {
            _context.All_departments.Add(departments);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // CRUD DEPARTMENTS END



        // CRUD POSITIONS START

        public async Task<IActionResult> All_Positions()
        {
            var all = _context.All_positions.ToList();


            return View(all);
        }

        public async Task<IActionResult> Add_Positions()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add_Positions(All_positions positions)
        {
            _context.All_positions.Add(positions);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // CRUD POSITIONS END




        // CRUD USERS START

        public async Task<IActionResult> All_Users()
        {
            var all = _context.All_users.Include(u=>u.Departments).Include(i=>i.Positions).ToList();


            return View(all);
        }

        public async Task<IActionResult> Add_Users()
        {

            var all = new All_Model_BInds
            {

                all_Departments_list = _context.All_departments.ToList(),
                all_Positions_list = _context.All_positions.ToList(),


            };


            return View(all);
        }
        [HttpPost]
        public async Task<IActionResult> Add_Users(All_Model_BInds users)
        {
            _context.All_users.Add(users.all_Users);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Dlt_Users(int id) {

            var all = _context.All_users.Find(id);

            _context.All_users.Remove(all);
        await   _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // CRUD USERS END

        // CRUD Risk Categories Strt
        public async Task<IActionResult> All_Risk_Categories()
        {

            var all = _context.Risk_Categories.ToList();

            return View(all);
        }

        public async Task<IActionResult> Add_Risk_Categories()
        {

            


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add_Risk_Categories(Risk_Categories risk)
        {
            _context.Risk_Categories.Add(risk);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Dlt_Risk_Categories(int id)
        {

            var all = _context.Risk_Categories.Find(id);

            _context.Risk_Categories.Remove(all);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // CRUD Risk Categories END


        // CRUD Audit Universe Start

        public async Task<IActionResult> All_Audit_universe()
        {
           
            var all = await _context.All_Audit_universes.Include(u => u.Departments).Include(i => i.Risks).ToListAsync();


            return View(all);
        }

        public async Task<IActionResult> Add_Audit_universe()
        {

            var all = new All_Model_BInds
            {
                all_Departments_list = _context.All_departments.ToList(),
                Risk_Categories = _context.Risk_Categories.ToList()

            };
            return View(all);
        }
        [HttpPost]
        public async Task<IActionResult> Add_Audit_universe(All_Model_BInds model)
        {

            string impact = model.all_Audits_Universe.Audit_Universe_Impact;
            string likelihood = model.all_Audits_Universe.Audit_Universe_likelihood;

            // Step 2: Convert to numeric values
            int impactValue = GetRiskValue(impact);
            int likelihoodValue = GetRiskValue(likelihood);

            // Step 3: Calculate risk ratio
            int riskRatio = impactValue * likelihoodValue;

            // Step 4: Set risk ratio in model
            model.all_Audits_Universe.Audit_Universe_Risk_ratio = riskRatio;

            // Step 5: Save to database
            _context.All_Audit_universes.Add(model.all_Audits_Universe);
           await _context.SaveChangesAsync();

          
            return RedirectToAction("Index");
        }
        private int GetRiskValue(string level)
        {
            return level switch
            {
                "Low" => 1,
                "Medium" => 2,
                "High" => 3,
                _ => 0
            };
        }
        public async Task<IActionResult> Dlt_Audit_universe(int id)
        {

            var all = _context.All_Audit_universes.Find(id);

            _context.All_Audit_universes.Remove(all);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        // CRUD Audit Universe END


        // CRUD Checklist Start
        public async Task<IActionResult> All_Checklist()
        {

            var all = _context.Add_checklists.Include(u=>u.Departments).ToList();

            return View(all);
        }

        public async Task<IActionResult> Add_Checklist()
        {
            var data = new All_Model_BInds
            {
                all_Departments_list = _context.All_departments.ToList()
            };



            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add_Checklist(All_Model_BInds list)
        {
            _context.Add_checklists.Add(list.all_Checklists);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Dlt_Checklist(int id)
        {

            var all = _context.Add_checklists.Find(id);

            _context.Add_checklists.Remove(all);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // CRUD Checklist END


        public IActionResult Ongoing_Audits()
        {
            var all = _context.Audit_Assigns_all.Include(i=>i.Audit_Universe.Departments).Include(o=>o.All_Users).ToList();
            return View(all);
        }

        public IActionResult Pending_task()
        {
            return View();
        }
        public IActionResult Complete_task()
        {
            return View();
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Remove("Position");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("Id");





            return RedirectToAction("Login");
        }

    }
}