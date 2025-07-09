using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;


using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PAMS.Controllers
{
    public class AuditController : Controller
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

      

        public IActionResult Details(int id)
        {
            
            return View();
        }


        public IActionResult Delete(int id)
        {
          
            return View();
        }


     }
}
