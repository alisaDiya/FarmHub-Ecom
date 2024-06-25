using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10037089__prog3ap2_Final_.Data;

namespace ST10037089__prog3ap2_Final_.Controllers
{
    public class marketplace : Controller
    {

        private readonly ApplicationDbContext _context;

        public marketplace(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString, DateTime? MinDate, DateTime? maxDate ,string searchStringf)
        {
            var products = _context.products.Select(b => b);

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(b => b.category.Contains(searchString) || b.productionDate.ToString().Contains(searchString)|| b.farmerName.Contains(searchString));
            }

            if (MinDate != null)
            {
                products = products.Where(b => b.productionDate >= MinDate);
            }

            if (maxDate != null)
            {
                products = products.Where(b => b.productionDate <= maxDate);
            }

          
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.products
                .FirstOrDefaultAsync(m => m.productid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

    }
}
