using KoiPond.Repositories.Models;
using KoiPond.Services;
using KoiPond.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoiPond.Controllers
{
    public class DuAnsController : Controller
    {
        private readonly IDuAnService _duAnService;

        public DuAnsController(IDuAnService duAnService)
        {
            _duAnService = duAnService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _duAnService.GetAllDuAnAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var sanPham = await _duAnService.GetDuAnByIdAsync(id.Value);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuAns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenDuAn,MoTa,UuDiem,KichThuoc,VatLieu,SoLuongCa,ThietKe,HinhAnh")] DuAn duAn, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                await _duAnService.AddDuAnAsync(duAn, uploadedFile);
                return RedirectToAction("Index");
            }
            return View(duAn);
        }

    }
}
