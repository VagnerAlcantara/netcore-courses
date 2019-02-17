using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        [TempData]
        public string Message { get; set; }

        public IList<Customer> Customers { get; private set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Customer customer = await _db.Customers.FindAsync(id);

            if(customer != null)
            {
                _db.Remove(customer);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
