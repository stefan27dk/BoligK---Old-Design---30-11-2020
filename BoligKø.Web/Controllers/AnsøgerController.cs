using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligKø.Web.Infrastructure.Dto;
using BoligKø.Web.Infrastructure.Request;
using BoligKø.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoligKø.Web.Controllers
{
     
    public class AnsøgerController : Controller
    {

        // Managers
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        private readonly IAnsøgerQuery ansøgerQuery;

        // || Constructor || ========================================================================
        public AnsøgerController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAnsøgerQuery ansøgerQuery)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ansøgerQuery = ansøgerQuery;
        }







        //==========||Ansøg||=========================================================================
        //Ansøg - || GET || --------------------------------------------
        [HttpGet]
        public IActionResult Ansøg()
        {
            // Check I Db om den UserID findes i en Ansøger ID i API
            // if ok --> return View() 
            // else return RedirectTo("Oplysninger", "Ansøger") - Så bruger kan Oprette sig som Ansøger med en bool at den er ikke oprettet sp man ikke skal søge i DB igen


            //:::::::::::::::::::::::::::::::::::::Rigtigt kode   
            //var result = ansøgerQuery.GetAsync(signInManager.UserManager.GetUserId(User));  

            //if (result != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Oplysninger", "Ansøger");
            //}





            // Midlertidig kode !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return View();

        }






        // Ansøg - || Post ||--------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Ansøg(AnsøgningViewModel model)
        {
            // :::::::::::::::::::::::::::::::Rigtigt kode
            //if (ModelState.IsValid)
            //{
            //    //Opret Ansøgning Kode Her-------------->
            //    if (AnsøgerCommandApiService.OpretAnsøgning(model)) // returns true or false
            //    {
            //        return RedirectToAction("Index", "Home");  // ####### Remember ReturnURl
            //    }
            //    else
            //    {
            //        return BadRequest(); // Senere vil der være Custom Error Pages fx. Kunne ikke oprettes "Fejl"
            //    }
            //}
            //else
            //{
            //    return View(model);
            //}





            // Midlertidig kode !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return View();
        }













        //==========||Opret - Ansøger||=========================================================================   
        //Oplysninger - Ansøger - || GET ||
        [HttpGet]
        public async Task<IActionResult> Oplysninger()
        {
            // Ikke nu !!!!!!!!!!!!if---> bool(ikke eksister == true) ---> return Empty View
            //Ikke nu !!!!!!!!!!!!!!Else ---> if---> bool(ikke eksister == false) ---> Søg i DB og hent Data

            //if exists ---> return ViewModel
            //else return empty View


            //::::::::::::::::::::::::::::::::::::::::::::Rigtigt kode    
            //AnsøgerDto dto = await ansøgerQuery.GetAsync(signInManager.UserManager.GetUserId(User)); // Returns Ansøger ViewModel

            //if (dto != null)
            //{
            //    var viewModel = new AnsøgerViewModel { Fornavn = dto.Fornavn, Efternavn = dto.Efternavn, Email = dto.Email, Id = dto.UserId, Tlf = 33333333 }; 
            //    return View(viewModel);
            //}
            //else
            //{
            //    return View();
            //}





            // Midlertidig kode !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return View();
        }






        //Oplysninger - Ansøger - || Post ||
        [HttpPost]
        public async Task<IActionResult> Oplysninger(AnsøgerViewModel model)
        {
            // :::::::::::::::::::::::::::::::Rigtigt kode
            //if (ModelState.IsValid)
            //{
            //    // Check Ansøger
            //    var apiModel = ansøgerQuery.GetAsync(signInManager.UserManager.GetUserId(User)); // Returns Ansøger ViewModel


            //    if (apiModel == null)
            //    {
            //        //Opret Ansøger Kode Her-------------->
            //        if (AnsøgerCommandApiService.OpretAnsøger(model)) // returns true or false
            //        {
            //            return RedirectToAction("Index", "Home");  // ####### Remember ReturnURl
            //        }
            //        else
            //        {
            //            return BadRequest(); // Senere vil der være Custom Error Pages fx. Kunne ikke oprettes "Fejl"
            //        }
            //    }
            //    else
            //    {
            //        //Update Ansøger Kode Her-------------->
            //        if (AnsøgerCommandApiService.UpdateAnsøger(model)) // returns true or false
            //        {
            //            return RedirectToAction("Index", "Home");  // ####### Remember ReturnURl
            //        }
            //        else
            //        {
            //            return BadRequest(); // Senere vil der være Custom Error Pages fx. Kunne ikke opdateres "Fejl"
            //        }
            //    }


            //}
            //else
            //{
            //    return View(model);
            //}





            // Midlertidig kode !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return RedirectToAction("Index", "Home"); 

        }

    }
}
