using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrailerOrder.Controllers
{
    public class AttendanceController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
    }
}
