using ExamenMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly MarketContext _context;

        public ProductController(MarketContext context)
        {
            _context = context;
        }





        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProducts(string name, double? price)
        {
            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(x => x.Name.Contains(name));
            }
            if (price.HasValue)
            {
                products = products.Where(x => x.Price == price.Value);
            }

            return Json(products.ToList());
        }

        

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult CreateProduct()
        {
            return PartialView("_CreateProductPartial");
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Products.Add(producto);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Registro exitoso" });
                }
                return Json(new { success = false, message = "Registro Incorrecto" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
