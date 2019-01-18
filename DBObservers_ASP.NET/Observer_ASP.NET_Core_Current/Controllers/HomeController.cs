using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Observer_ASP.NET_Core_Current.Models;

namespace Observer_ASP.NET_Core_Current.Controllers
{
    public class HomeController : Controller
    {
        private EquipmentContext db;
        public HomeController(EquipmentContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Equipments.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            equipment.EquipmentType = new EquipmentType() {Name = equipment.EquipmentTypeString};
            db.Equipments.Add(equipment);
            db.EquipmentTypes.Add(equipment.EquipmentType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
