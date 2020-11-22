using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligKø.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BoligKø.Web.Controllers
{
    public class AnsøgerController : Controller
    {
       
        [HttpGet]
        public IActionResult Ansøg()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Ansøg(AnsøgningViewModel model)
        {
            return View();
        }


    }
}
