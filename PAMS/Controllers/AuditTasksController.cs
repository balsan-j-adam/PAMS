using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace PAMS.Controllers
{
    public class AuditTasksController : Controller
    {
        
        public IActionResult Index()
        {
          
            return View();
        }


        public IActionResult Create()
        {
           
            return View();
        }

    


        public IActionResult Edit(int id)
        {
        
            return View();
        }

        


        public IActionResult Delete(int id)
        {
           
            return View();
        }


    }
}
