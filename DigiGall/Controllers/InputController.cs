using DigiGall.Data;
using Microsoft.AspNetCore.Mvc;

namespace DigiGall.Controllers
{
   public class InputController : Controller
   {
      [HttpGet]
      public IActionResult Add()
      {
         return View();
      }
   }
}

