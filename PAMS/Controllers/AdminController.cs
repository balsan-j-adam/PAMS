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
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(All_users user )
        {

            var data = _context.All_users.FirstOrDefault(u => u.User_email == user.User_email);
            if(data != null && data.User_pass == user.User_pass)
            {
                HttpContext.Session.SetString("Role", data.User_Role);

                if (data.User_Role == "Admin")
                {

                    return RedirectToAction("Index");
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




    }
}