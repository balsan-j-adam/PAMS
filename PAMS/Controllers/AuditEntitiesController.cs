using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace PAMS.Controllers
{
    public class AuditEntitiesController : Controller
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
