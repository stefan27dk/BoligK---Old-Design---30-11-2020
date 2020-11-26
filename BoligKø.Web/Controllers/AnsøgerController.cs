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










        //==========||Opret - Ansøger||=========================================================================


        //Oplysninger - Ansøger - || GET ||
        [HttpGet]
        public IActionResult Oplysninger()
        {  
            return View();
        }






        //Oplysninger - Ansøger - || Post ||
        [HttpPost]
        public async Task<IActionResult> Oplysninger(AnsøgerViewModel model)
        {

            return View();
            //if (ModelState.IsValid)
            //{
            //    //Opret Ansøger Kode Her-->
            //    return RedirectToAction("Index", "Home");
            //}

            //return RedirectToPage("Error");

        }

    }
}
