using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    //  HTTP Verps: HTTPGET: Bring  HTTPPOST:Send
    public class ProductsController : Controller
    {
        // Mapping URL

        ApplicationDbContext context = new ApplicationDbContext();

        //List<Product> allproducts = new List<Product>
        // {
        //     new Product{Id=1001,Name="iPhone",Price=35000,Description="Premium" ,Image="Iphone.jpg" }  ,
        //     new Product{Id=1002,Name="Samsung",Price=10000,Description="Ultimate",  Image="Samsung.jpg" }  ,
        //     new Product{Id=1003,Name="Oppo",Price=8000,Description="Stylish",    Image="Oppo.jpg"}  ,
        //     new Product{Id=1004,Name="Xiamo",Price=20000,Description="Affordable",Image="Xiamo.jpg" }

        // };

        //Bring
        [HttpGet]
        public IActionResult Index()
        {
            //table
            return View("Index", context.Products.ToList());
        }

        //[HttpGet]
        //public IActionResult Getinexview()
        //{

        //    return View("Index", context.Products.ToList());
        //}


        // for search
        [HttpGet]
        public IActionResult Getinexview(string? search)
        {
            if (string.IsNullOrEmpty(search) == false)
            {
                return View("Index", context.Products.Where(e => e.Name.Contains(search) ||
                                                                   e.Description.Contains(search)).ToList());

            }
            else
                return View("Index", context.Products.ToList());
        }

        [HttpGet]
        public IActionResult GetDeatilsView(int Id)

        {                            //Dbset
            Product product = context.Products.Include(e=>e.category).FirstOrDefault(e => e.Id == Id);
            if (product is null) return NotFound();
            return View("Details", product);  //Object
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Product product = context.Products.Include(e=>e.category).FirstOrDefault(e => e.Id == Id);
            if (product is null) return NotFound();
            return View(product);      //Object
        }

        [HttpGet]
        public IActionResult GetCreateView()
        {
            return View("Create");
        }

        //[HttpGet]
        //public IActionResult Create()
        //{


        //    return View();
        //}



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
            return View();
        }







        //دى ال هتروح تسمع في الداتا بيزز وتضيف الداتا    ودى بعتاها اصلا لل فورم ال في ال كرريت فيو 
        //بتسيند الداتا


        //[HttpPost]         // addnew ال بتسمع في ال داتا بيز
        //public IActionResult AddNew(Product product)
        //{
        //    product.Id = 0;
        //    if (product.ImageFile != null)
        //    {

        //        string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");


        //        string fileName = Path.GetFileName(product.ImageFile.FileName);


        //        string path = Path.Combine(wwwRootPath, fileName);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            product.ImageFile.CopyTo(stream);
        //        }

        //        product.Image = fileName;
        //    }
        //    else
        //    {

        //        product.Image = "default.jpg";
        //    }


        //    if (ModelState.IsValid == true)
        //    {
        //        context.Products.Add(product);

        //        context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //        return View("Create", product);


        //}




        [HttpPost]
        public IActionResult AddNew(Product product)
        {
            if (product.ImageFile != null)
            {
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                string fileName = Path.GetFileName(product.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    product.ImageFile.CopyTo(stream);
                }

                product.Image = fileName;
            }
            else
            {
                product.Image = "default.jpg";
            }

            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name");
            return View("Create", product);
        }







        [HttpGet]
        public IActionResult GetDeleteView(  int Id)
        {
            Product product = context.Products.Include(e=>e.category).FirstOrDefault(e => e.Id == Id);
            if (product is null) return NotFound();
            return View("Delete", product);

        }

        [HttpPost]
        public IActionResult DeleteCurrent(int Id)
        {
            Product product = context.Products.FirstOrDefault(e => e.Id == Id);

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Getinexview));
        }

        //public IActionResult GetEditView(int Id)

        //{                            //Dbset
        //    Product product = context.Products.FirstOrDefault(e => e.Id == Id);
        //    if (product is null) return NotFound();
        //    return View("Edit", product);  //Object
        //}

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();

            ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name", product.CategoryId);
            return View("Edit", product);
        }








        //public IActionResult EditCurrent(Product product)
        //{
        //    if (product.ImageFile != null)
        //    {

        //        string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");


        //        string fileName = Path.GetFileName(product.ImageFile.FileName);


        //        string path = Path.Combine(wwwRootPath, fileName);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            product.ImageFile.CopyTo(stream);
        //        }

        //        product.Image = fileName;
        //    }
        //    else
        //    {

        //        product.Image = "default.jpg";
        //    }


        //    if (ModelState.IsValid == true)
        //    {
        //        context.Products.Update(product);
        //        context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //        return View("Edit", product);


        //}



        [HttpPost]
        public IActionResult EditCurrent(Product product)
        {
            if (!ModelState.IsValid)
            {
                
                ViewBag.Categories = new SelectList(context.Categories.ToList(), "Id", "Name", product.CategoryId);
                return View("Edit", product);
            }

            var dbProduct = context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (dbProduct is null) return NotFound();

            
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Description = product.Description;
            dbProduct.CategoryId = product.CategoryId;

            
            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                Directory.CreateDirectory(root); // 
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(product.ImageFile.FileName)}"; 
                var path = Path.Combine(root, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    product.ImageFile.CopyTo(stream);
                }
                dbProduct.Image = fileName;
            }

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }









    }
}
