using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DigiGall.Controllers
{

    //[Authorize(Roles = "Prefect")]
    public class InputController : Controller
   {
      private readonly ApplicationDbContext dbContext;
        
      public InputController(ApplicationDbContext dbContext)
      {
          this.dbContext = dbContext; 
      }

      [HttpGet]
      public IActionResult Add()
      {
         return View();
      }
       
      [HttpPost]
      public async Task<IActionResult> Add(AddStudentViewModel viewModel)
      {
            var student = new User
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Galleon = viewModel.Galleon
            };

            await dbContext.User.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
      }
        
      [HttpGet]
      public async Task<IActionResult> List()
      {
            var students = await dbContext.User.ToListAsync();
                
            return View(students);  
      }

      [HttpGet]
      public async Task<IActionResult> Edit(String id)
      {
          var student = await dbContext.User.FindAsync(id);
      
          return View(student); 
      }

      [HttpPost]
      public async Task<IActionResult> Edit(User viewModel)
        {
            var student = await dbContext.User.FindAsync(viewModel.Id);
        
            if(student is not null)
            {
                student.Id = viewModel.Id;
                student.Name = viewModel.Name;
                student.Galleon = viewModel.Galleon;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Input");
        }
   }
}

