using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AdminDashBoard.ViewModel;
using ApiContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Azure.Core;
using AdminDashBoard.Models;

namespace AdminDashBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly DBContext dBContext;

        public CategoryController(DBContext _dBContext)
        {
            dBContext = _dBContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            List<GetAllCategory> getAllCategories = new List<GetAllCategory>(); ;

            var data = dBContext.Categories.Select(a => new GetAllCategory
            {
                Id = a.Id,
                Name = a.Name,
                NameArabic = a.NameArabic,
                ImagePath = a.ImagePath
            });
            return View(data);
        }


        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            return View(dBContext.Categories.FirstOrDefault(e=>e.Id==id));
        }

        // GET: Category/Create
        public async Task<ActionResult> Create()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            var viewModel = new Models.Category
            {
                category = new SelectList(dBContext.Categories.Select(a => new GetAllCategory { Id = a.Id, Name = a.Name }), "Id", "Name")
            };

            if (viewModel == null)
            {
                return View();
            }
            else
                return View(viewModel);
        }

        // POST: Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(Models.Category category)
        {

            var file = category.Images;
            if (file == null || file.Length == 0)
                return BadRequest("Please select an image");

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = System.IO.Path.Combine(currentDirectory, "CategoryImages");
            if (!System.IO.Directory.Exists(imagePath))
            {
                System.IO.Directory.CreateDirectory(imagePath);
            }
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(imagePath, fileName);



            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            category.ImagePath = filePath;

            
            var min = new Domain.Category()
            {
                Name = category.Name,
                NameArabic = category.NameArabic,
                ImagePath = category.ImagePath,
                parentId= category.ParentCategory
            };

            if (category.ParentCategory != null)
            {
                min.parentId = category.ParentCategory;


            }
            await dBContext.Categories.AddAsync(min);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Edit(int Id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            var category = dBContext.Categories.Where(a => a.Id == Id).FirstOrDefault();
            if (category == null)
                return NotFound();
            else
            {


                Models.Category min = new Models.Category();
                min.Id = category.Id;
                min.Name = category.Name;
                min.NameArabic = category.NameArabic;

                min.category = new SelectList(dBContext.Categories.Select(a => new GetAllCategory { Id = a.Id, Name = a.Name }), "Id", "Name");



                return View(min);
            }
        }

        [HttpPost]

        public async Task<ActionResult> Edit(Models.Category category)
        {
            var cat = await dBContext.Categories.FirstOrDefaultAsync(p => p.Id == category.Id);

            if (cat == null)
            {
                return NotFound();
            }


            var file = category.Images;
            if (file == null || file.Length == 0)
                return BadRequest("Please select an image");

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = System.IO.Path.Combine(currentDirectory, "CategoryImages");
            if (!System.IO.Directory.Exists(imagePath))
            {
                System.IO.Directory.CreateDirectory(imagePath);
            }
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(imagePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            cat.ImagePath = filePath;
            // Update the properties of the product
            cat.Name = category.Name;
            cat.NameArabic = category.NameArabic;
           
            cat.parentId = category.ParentCategory;
            // Save changes to the database
            dBContext.SaveChanges();

            // Redirect back to the product details page
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            //string apiUrl = $"http://localhost:5000/api/Category/DeleteCategory/{id}";

            //HttpClient httpClient = new HttpClient();
            //HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);
            //if (response.IsSuccessStatusCode)
            //    return RedirectToAction("Index");
            //else

            //    return BadRequest("Error!");
            var cat = dBContext.Categories.Where(e => e.Id == id).FirstOrDefault();
            if (cat != null)
            {
                dBContext.Categories.Remove(cat);
                dBContext.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return NotFound("Category not found");
            }
        }

        
    }
}
