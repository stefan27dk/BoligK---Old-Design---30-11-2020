using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligKø.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoligKø.Web.Controllers
{
     
    public class AnsøgerController : Controller
    {



        //==========||Ansøg||=========================================================================
        //Ansøg - || GET ||
        [HttpGet]
        public IActionResult Ansøg()
        {
            return View();
        }


         // Ansøg - || Post ||
        [HttpPost]
        public async Task<IActionResult> Ansøg(AnsøgningViewModel model)
        {
            return View();
        }










        //==========||Create - Ansøger||=========================================================================
        //Ansøger - || Post ||
        [HttpPost]
        public async Task<IActionResult> Create(AnsøgerViewModel model)
        {
           //Opret Ansøger Kode Her-->
            return View();
        }

    }
}
