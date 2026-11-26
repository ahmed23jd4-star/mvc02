using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.context;

namespace WebApplication2.Controllers
{
    public class planController : Controller
    {
        private readonly gymdbcontext _dbcontext = new gymdbcontext();

        public async Task<IActionResult> Index()
        {
            var plans = await _dbcontext.plans
                                        .AsNoTracking()
                                        .ToListAsync();
            return View(plans);
        }
    }
}
