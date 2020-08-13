using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUII.Controllers
{
    public class UrunController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
